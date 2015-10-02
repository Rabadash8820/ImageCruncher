#include "ImageFilter.h"
#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <ctime>

// GLOBAL DATA
std::map<ImageFilter::SortMethod, std::string> sortMethodStr{
	{ ImageFilter::SortMethod::InsertionSort, "Insertion Sort" },
	{ ImageFilter::SortMethod::QuickSort, "Quick Sort" },
	{ ImageFilter::SortMethod::BubbleSort, "BubbleSort" },
};
enum ErrorState {
	ErrorFree = 0,
	SyntaxError = 1,
	WindowSizeError = 2,
	PgmFormatError = 3,
	FileOpenError = 4,
};

// HELPER FUNCTIONS
bool hasExtension(const char* filePath, std::string extension) {
	// Try to match the last characters of the filePath to the extension
	std::string filePathStr(filePath);
	size_t length = filePathStr.length();
	size_t extLength = extension.length();
	for (size_t c = extLength; c > 0; --c) {
		if (filePathStr[length - c] != extension[extLength - c])
			return false;
	}
	return true;
}
ImageFilter::SortMethod chosenMethod(const char* parameter) {
	int choice = atoi(parameter);
	switch (choice) {
	case 1:
		return ImageFilter::SortMethod::InsertionSort;
	case 2:
		return ImageFilter::SortMethod::QuickSort;
	case 3:
		return ImageFilter::SortMethod::BubbleSort;
	default:
		std::cout << "ERROR: Invalid sort method entered.  Using default method (insertion sort)." << std::endl;
		return ImageFilter::SortMethod::InsertionSort;
	}

}
void showCorrectSyntax(const char* exePath) {
	std::cerr << "The syntax of the command is incorrect." << std::endl;
	std::cerr << "\nUsage: " << exePath << " <WINDOW_SIZE> <FILE_PATH> [SORT_METHOD]" << std::endl;
	std::cerr << "Image file is assumed to be in the current directory." << std::endl;
	std::cerr << "Options for sort method:" << std::endl
		<< "\t1 - " << sortMethodStr[ImageFilter::SortMethod::InsertionSort] << " (default)" << std::endl
		<< "\t2 - " << sortMethodStr[ImageFilter::SortMethod::QuickSort] << std::endl
		<< "\t3 - " << sortMethodStr[ImageFilter::SortMethod::BubbleSort] << std::endl;
}
ErrorState loadCommLineArgs(int argc, char* argv[], int& winSize, const char*& filePath, ImageFilter::SortMethod& sortMethod) {
	// If an incorrect number of parameters was passed, then explain the proper usage
	if (argc != 3 && argc != 4)
		return ErrorState::SyntaxError;

	// Check that a valid window size was entered
	winSize = atoi(argv[1]);
	if (winSize < 3 || winSize % 2 == 0)
		return WindowSizeError;

	// Make sure the file exists and is a PGM file
	filePath = argv[2];
	bool isPGM = hasExtension(filePath, "pgm");
	if (!isPGM)
		return PgmFormatError;
	std::ifstream picture(filePath);
	if (!picture.is_open())
		return FileOpenError;

	// Get the sort method (default is insertion sort)
	sortMethod = ImageFilter::SortMethod::InsertionSort;
	if (argc == 4)
		sortMethod = chosenMethod(argv[3]);

	return ErrorFree;
}
void runFilter(const char* filePath, int winSize, ImageFilter::SortMethod sortMethod) {
	// Save a new picture that is the watercolor-filtered copy of the original, and record the time it took
	std::cout << "Applying watercolor filter with " << sortMethodStr[sortMethod] << " and window-size of " << winSize << "..." << std::endl;
	clock_t start = clock();
	filePath = ImageFilter::watercolor(filePath, winSize, sortMethod);
	clock_t finish = clock();
	double seconds = (finish - start) / (double)CLOCKS_PER_SEC;

	// Inform the user of the operation's completion
	std::cout << std::endl
			  << "Operation completed in " << seconds << " seconds." << std::endl
			  << "Filtered image saved as " << filePath << std::endl;
}

// MAIN FUNCTION
int main(int argc, char* argv[]) {
	system("cls");

	// Load command line arguments into type-specific variables
	int winSize;
	const char* filePath;
	ImageFilter::SortMethod sortMethod;
	ErrorState errState = loadCommLineArgs(argc, argv, winSize, filePath, sortMethod);

	// Output the appropriate error or success messages to the console
	switch (errState) {
	case SyntaxError:
		showCorrectSyntax(argv[0]);
		break;
	case WindowSizeError:
		std::cerr << "ERROR: Window size must be an odd number greater than or equal to 3" << std::endl;
		break;
	case PgmFormatError:
		std::cerr << "ERROR: File " << filePath << " is not in PGM format." << std::endl;
		break;
	case FileOpenError:
		std::cerr << "ERROR: Could not open file at path " << filePath << std::endl;
		break;
	default:
		runFilter(filePath, winSize, sortMethod);
	}

	return errState;
}