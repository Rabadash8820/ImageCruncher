#include "PgmFilter.h"
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <string>
#include <map>
#include <ctime>

// GLOBAL DATA
PgmFilter::SortMethod sortMethod[3] = {
	PgmFilter::SortMethod::InsertionSort,
	PgmFilter::SortMethod::QuickSort,
	PgmFilter::SortMethod::BubbleSort,
};
std::map<PgmFilter::SortMethod, std::string> sortMethodStr{
	{ PgmFilter::SortMethod::InsertionSort, "Insertion Sort" },
	{ PgmFilter::SortMethod::QuickSort, "Quick Sort" },
	{ PgmFilter::SortMethod::BubbleSort, "BubbleSort" },
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
	int length = filePathStr.length();
	int extLength = extension.length();
	for (int c = extLength; c > 0; --c) {
		if (filePathStr[length - c] != extension[extLength - c])
			return false;
	}
	return true;
}
PgmFilter::SortMethod chosenMethod(const char* parameter) {
	int choice = atoi(parameter);
	switch (choice) {
	case 1:
	case 2:
	case 3:
		return sortMethod[choice - 1];
	default:
		std::cout << "ERROR: Invalid sort method entered.  Using default method (insertion sort)." << std::endl;
		return PgmFilter::SortMethod::InsertionSort;
	}

}
void showCorrectSyntax(const char* exePath) {
	std::cerr << "The syntax of the command is incorrect." << std::endl;
	std::cerr << "\nUsage: " << exePath << " <WINDOW_SIZE> <FILE_PATH> [SORT_METHOD]" << std::endl;
	std::cerr << "Options for sort method:" << std::endl
		<< "\t1 - " << sortMethodStr[PgmFilter::SortMethod::InsertionSort] << " (default)" << std::endl
		<< "\t2 - " << sortMethodStr[PgmFilter::SortMethod::QuickSort] << std::endl
		<< "\t3 - " << sortMethodStr[PgmFilter::SortMethod::BubbleSort] << std::endl;
}
ErrorState loadCommLineArgs(int argc, char* argv[], int& winSize, const char*& filePath, PgmFilter::SortMethod& sortMethod) {
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
	sortMethod = PgmFilter::SortMethod::InsertionSort;
	if (argc == 4)
		sortMethod = chosenMethod(argv[3]);

	return ErrorFree;
}
void runFilter(const char* filePath, int winSize, PgmFilter::SortMethod sortMethod) {
	// Save a new picture that is the watercolor-filtered copy of the original
	std::cout << "Applying watercolor filter with " << sortMethodStr[sortMethod] << " and window-size of " << winSize << "..." << std::endl;
	clock_t start = clock();
	filePath = PgmFilter::watercolor(filePath, winSize, sortMethod);
	clock_t finish = clock();
	double seconds = (finish - start) / (double)CLOCKS_PER_SEC;
	std::cout << "Operation completed in " << seconds << " seconds." << std::endl
		<< "Filtered image saved as " << filePath << std::endl;

}

// MAIN FUNCTION
int main(int argc, char* argv[]) {
	system("cls");

	// Load command line arguments into type-specific variables
	int winSize;
	const char* filePath;
	PgmFilter::SortMethod sortMethod;
	ErrorState errState = loadCommLineArgs(argc, argv, winSize, filePath, sortMethod);

	// Output the appropriate error or success messages to the console
	switch (errState) {
	case SyntaxError:
		showCorrectSyntax(argv[0]);
	case WindowSizeError:
		std::cerr << "ERROR: Window size must be an odd number greater than or equal to 3" << std::endl;
	case PgmFormatError:
		std::cerr << "ERROR: File " << filePath << " is not in PGM format." << std::endl;
	case FileOpenError:
		std::cerr << "ERROR: Could not open file " << filePath << std::endl;
	default:
		runFilter(filePath, winSize, sortMethod);
	}

	return errState;
}
