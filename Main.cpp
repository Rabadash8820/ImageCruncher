#include "PictureFilter.h"
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <string>
#include <map>
#include <ctime>

// GLOBAL VARIABLES
PictureFilter::SortMethod sortMethod[3] = {
	PictureFilter::SortMethod::InsertionSort,
	PictureFilter::SortMethod::QuickSort,
	PictureFilter::SortMethod::BubbleSort,
};
std::map<PictureFilter::SortMethod, std::string> sortMethodStr {
	{ PictureFilter::SortMethod::InsertionSort, "Insertion Sort"},
	{ PictureFilter::SortMethod::QuickSort, "Quick Sort" },
	{ PictureFilter::SortMethod::BubbleSort, "BubbleSort" },
};

// HELPER FUNCTIONS
std::string renameWithExtension(std::string filePath, std::string extension) {
	// Try to match the last characters of the filePath to the extension
	int length = filePath.length();
	int extLength = extension.length();
	for (int c = extLength; extLength > 0; --c) {
		if (filePath[length - c] != extension[extLength - c])
			return false;
	}
}
bool hasExtension(std::string filePath, std::string extension) {
	// Try to match the last characters of the filePath to the extension
	int length = filePath.length();
	int extLength = extension.length();
	for (int c = extLength; extLength > 0; --c) {
		if (filePath[length - c] != extension[extLength - c])
			return false;
	}
	return true;
}
PictureFilter::SortMethod chosenMethod(const char* parameter) {
	int choice = atoi(parameter);
	switch (choice) {
	case 1:
	case 2:
	case 3:
		return sortMethod[choice - 1];
	default:
		std::cout << "ERROR: Invalid sort method entered.  Using default method (insertion sort)." << std::endl;
		return PictureFilter::SortMethod::InsertionSort;
	}

}

// MAIN FUNCTION
int main(int argc, char* argv[]) {
	system("cls");

	// If an incorrect number of parameters was passed, then explain the proper usage
	if (argc != 3 && argc != 4) {
		std::cerr << "The syntax of the command is incorrect." << std::endl;
		std::cerr << "\nUsage: " << argv[0] << " <WINDOW_SIZE> <FILE_PATH> [SORT_METHOD]" << std::endl;
		std::cerr << "Options for sort method:" << std::endl
			<< "\t1 - " << sortMethodStr[PictureFilter::SortMethod::InsertionSort] << " (default)" << std::endl
			<< "\t2 - " << sortMethodStr[PictureFilter::SortMethod::QuickSort] << std::endl
			<< "\t3 - " << sortMethodStr[PictureFilter::SortMethod::BubbleSort] << std::endl;

		return 1;
	}

	// Check that a valid window size was entered
	int winSize = atoi(argv[1]);
	if (winSize < 3 || winSize % 2 == 0) {
		std::cerr << "ERROR: Window size must be an odd number greater than or equal to 3" << std::endl;
		return 2;
	}

	// Make sure the file exists and is a PGM file
	std::string filePath(argv[2]);
	bool isPGM = hasExtension(filePath, "pgm");
	if (!isPGM) {
		std::cerr << "ERROR: File " << filePath << " is not in PGM format." << std::endl;
		return 3;
	}
	std::ifstream picture(filePath);
	if (!picture.is_open()) {
		std::cerr << "ERROR: Could not open file " << filePath << std::endl;
		return 4;
	}

	// Get the sort method (default is insertion sort)
	PictureFilter::SortMethod sortMethod = PictureFilter::SortMethod::InsertionSort;
	if (argc == 4)
		sortMethod = chosenMethod(argv[3]);

	// Save a new picture that is the watercolor-filtered copy of the original
	std::cout << "Applying watercolor filter with " << sortMethodStr[sortMethod] << " and window-size of " << winSize << "..." << std::endl;
	clock_t start = clock();
	PictureFilter::watercolor(filePath, winSize, sortMethod);
	clock_t finish = clock();
	std::cout << "Operation completed in " << (finish - start) / CLOCKS_PER_SEC << " seconds." << std::endl
		      << "New image saved as " << filePath << "" << std::endl;

	return 0;
}