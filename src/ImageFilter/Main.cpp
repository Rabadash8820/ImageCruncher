#include "ImageFilter.h"
#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <ctime>
#include <cstdlib>

// GLOBAL DATA
enum class ErrorState {
	ErrorFree,
	SyntaxError,
	InvalidOptionError,
	WindowSizeError,
	PgmFormatError,
	FileOpenError,
};

// ABSTRACT DATA TYPES
struct Options {
	bool showOutput;
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
void showCorrectSyntax(const char* exePath) {
	std::cerr << "The syntax of the command is incorrect." << std::endl
			  << "\nUsage: ImageFilter.exe [options] <window_size> <file_path>" << std::endl
			  << "Image file is assumed to be in the current directory." << std::endl
			  << "\nOptions:" << std::endl
			  << "\t-o\tShow output for debugging purposes" << std::endl;
}
Options defaultOptions(bool& showOutput) {
	Options options;

	options.showOutput = false;

	return options;
}
ErrorState loadCommLineArgs(int argc, char* argv[], int& winSize, const char*& filePath, bool& showOutput) {
	// If an incorrect number of parameters was passed, then explain the proper usage
	if (argc < 2 || 4 < argc)
		return ErrorState::SyntaxError;

	// Make sure that all provided options are defined
	int a = 0;
	bool isFlag;
	do {
		++a;
		char* arg = argv[a];
		isFlag = (arg[0] == '-');
		if (isFlag) {
			bool validFlag = (strcmp(arg, "-o") == 0 || strcmp(arg, "-O") == 0);
			if (!validFlag)
				return ErrorState::InvalidOptionError;
			arg[1] = tolower(arg[1]);
		}
	} while (isFlag);

	// Set flags according to the provided options
	Options options = defaultOptions(showOutput);
	showOutput = options.showOutput;
	for (int f = 1; f < a; ++f) {
		showOutput = (strcmp(argv[f], "-o") == 0);
	}

	// Check that a valid window size was entered
	winSize = atoi(argv[a]);
	if (winSize < 3 || winSize % 2 == 0)
		return ErrorState::WindowSizeError;

	// Make sure the file exists and is a PGM file
	++a;
	filePath = argv[a];
	bool isPGM = hasExtension(filePath, "pgm");
	if (!isPGM)
		return ErrorState::PgmFormatError;
	std::ifstream picture(filePath);
	if (!picture.is_open())
		return ErrorState::FileOpenError;
	picture.close();

	return ErrorState::ErrorFree;
}
void runFilter(const char* filePath, int winSize, bool showOutput) {
	// Save a new picture that is the watercolor-filtered copy of the original, and record the time it took
	std::cout << "Applying watercolor filter with window-size of " << winSize << "..." << std::endl;
	clock_t start = clock();
	ImageFilter imgFilter(filePath, showOutput);
	filePath = imgFilter.watercolor(winSize);
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
	bool showOutput;
	ErrorState errState = loadCommLineArgs(argc, argv, winSize, filePath, showOutput);

	// Output the appropriate error or success messages to the console
	switch (errState) {
	case ErrorState::SyntaxError:
		showCorrectSyntax(argv[0]);
		break;

	case ErrorState::InvalidOptionError:
		std::cerr << "ERROR: Invalid option provided" << std::endl;
		break;

	case ErrorState::WindowSizeError:
		std::cerr << "ERROR: Window size must be an odd number greater than or equal to 3" << std::endl;
		break;

	case ErrorState::PgmFormatError:
		std::cerr << "ERROR: File " << filePath << " is not in PGM format." << std::endl;
		break;

	case ErrorState::FileOpenError:
		std::cerr << "ERROR: Could not open file at path " << filePath << std::endl;
		break;

	default:
		runFilter(filePath, winSize, showOutput);
	}

	return 0;
}