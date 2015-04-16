#include "PictureFilter.h"
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <string>
#include <map>
#include <ctime>

// GLOBAL VARIABLES
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

// HELPER FUNCTIONS
bool hasExtension(std::string filePath, std::string extension) {
	// Try to match the last characters of the filePath to the extension
	int length = filePath.length();
	int extLength = extension.length();
	for (int c = extLength; c > 0; --c) {
		if (filePath[length - c] != extension[extLength - c])
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

// MAIN FUNCTION
int main(int argc, char* argv[]) {
	system("cls");

	// If an incorrect number of parameters was passed, then explain the proper usage
	if (argc != 3 && argc != 4) {
		std::cerr << "The syntax of the command is incorrect." << std::endl;
		std::cerr << "\nUsage: " << argv[0] << " <WINDOW_SIZE> <FILE_PATH> [SORT_METHOD]" << std::endl;
		std::cerr << "Options for sort method:" << std::endl
			<< "\t1 - " << sortMethodStr[PgmFilter::SortMethod::InsertionSort] << " (default)" << std::endl
			<< "\t2 - " << sortMethodStr[PgmFilter::SortMethod::QuickSort] << std::endl
			<< "\t3 - " << sortMethodStr[PgmFilter::SortMethod::BubbleSort] << std::endl;

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
	PgmFilter::SortMethod sortMethod = PgmFilter::SortMethod::InsertionSort;
	if (argc == 4)
		sortMethod = chosenMethod(argv[3]);

	// Save a new picture that is the watercolor-filtered copy of the original
	std::cout << "Applying watercolor filter with " << sortMethodStr[sortMethod] << " and window-size of " << winSize << "..." << std::endl;
	clock_t start = clock();
	//filePath = PgmFilter::watercolor(filePath, winSize, sortMethod);
	clock_t finish = clock();
	double seconds = (finish - start) / (double)CLOCKS_PER_SEC;
	std::cout << "Operation completed in " << seconds << " seconds." << std::endl
		      << "Filtered image saved as " << filePath << std::endl;

	return 0;
}