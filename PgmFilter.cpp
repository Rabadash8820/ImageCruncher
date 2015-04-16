#include "PgmFilter.h"
#include <string>

// PROTECTED CONSTRUCTOR
PgmFilter::PgmFilter() {}

// INTERFACE FUNCTIONS
const char* PgmFilter::watercolor(const std::string& filePath, const int winSize, SortMethod sortMethod) {
	return watercolor(filePath.c_str(), winSize, sortMethod);
}
const char* PgmFilter::watercolor(const char* filePath, const int winSize, SortMethod sortMethod) {
	// Load data from the PGM file
	int width, height;
	int maxGrey;
	int** pixels;
	loadPgmData(filePath, width, height, maxGrey, pixels);

	// Apply the filter to the pixel array just loaded
	//watercolorFilter(pixels, width, height, winSize, sortMethod);

	// Create a new PGM file with the filtered pixel array and return its path
	const char* newFilePath = renameWithSuffix(filePath, "_watercolor");
	createPgm(newFilePath, width, height, maxGrey, pixels);
	return newFilePath;
}
void PgmFilter::loadPgmData(const char* filePath, int& width, int& height, int& maxGrey, int**& pixels) {
	// Open the picture
	std::ifstream picture(filePath);

	// Skip the PGM identifier on the first line
	std::string lineStr;
	std::getline(picture, lineStr);

	// Get the image's dimensions (skipping over any comments)
	std::getline(picture, lineStr);
	while (lineStr[0] == '#')
		std::getline(picture, lineStr);
	int spacePos = lineStr.find(' ');
	width = std::stoi(lineStr.substr(0, spacePos));
	height = std::stoi(lineStr.substr(spacePos + 1));

	// Get the image's max greyscale value (skipping over any comments
	std::getline(picture, lineStr);
	while (lineStr[0] == '#')
		std::getline(picture, lineStr);
	maxGrey = std::stoi(lineStr);

	// Store the actual pixel values into a 2D array
	pixels = new int*[height];
	for (int i = 0; i < height; ++i)
		pixels[i] = new int[width];
	for (int r = 0; r < height; ++r) {
		std::getline(picture, lineStr);
		for (int c = 0; c < width; ++c) {
			int spacePos = lineStr.find(' ');
			int pixel = std::stoi(lineStr.substr(0, spacePos));
			lineStr = lineStr.substr(spacePos + 1);
			pixels[r][c] = pixel;
		}
	}

	// Close the picture
	picture.close();
}
void PgmFilter::createPgm(const char* filePath, int width, int height, int maxGrey, int**& pixels) {
	// Open the picture
	std::ofstream picture(filePath);

	// Store header information into the new PGM file
	picture << "P2" << std::endl
			<< "# Generated programmatially on " << std::endl
			<< width << " " << height << std::endl
			<< maxGrey << std::endl;

	// Store filtered pixel values into the file
	for (int r = 0; r < height; ++r) {
		for (int c = 0; c < width; ++c)
			picture << pixels[r][c] << " ";
		picture << std::endl;
	}

	// Close the picture
	picture.close();
}
const char* PgmFilter::renameWithSuffix(const char* oldFilePath, const std::string& suffix) {
	std::string filePathStr(oldFilePath);
	size_t periodPos = filePathStr.find('.');
	filePathStr.insert(periodPos, suffix);
	return filePathStr.c_str();
}
void PgmFilter::watercolorFilter(int** pixels, int width, int height, int winSize, SortMethod sortMethod) {
	// Make a new array to hold the filtered pixels
	int** fPixels = new int*[height];
	for (int i = 0; i < height; ++i)
		fPixels[i] = new int[width];

	// Loop over each pixel
	for (int row = 0; row < height; ++row) {
		for (int col = 0; col < width; ++col) {
			// Create a window around this pixel
			int i = -1;
			int bound = winSize / 2;
			int* window = new int[winSize * winSize];
			for (int rOffset = -bound; rOffset <= bound; ++rOffset) {
				for (int cOffset = -bound; cOffset <= bound; ++cOffset) {
					int r = row + rOffset;
					int c = col + cOffset;
					if ((0 <= r && r < height) && (0 <= c && c < width))
						window[++i] = pixels[r][c];
				}
			}

			// Set the value of the filtered pixel at this position to the median value of the window
			int med = median(window, winSize * winSize, sortMethod);
			fPixels[row][col] = med;
		}
	}

	// Store the array of filtered pixels back into the original array
	for (int r = 0; r < height; ++r) {
		for (int c = 0; c < width; ++c)
			pixels[r][c] = fPixels[r][c];
	}
}
int PgmFilter::median(int* window, int size, SortMethod sortMethod) {
	// Sort the array according to the provided method
	void(*sort)(int*&, int);
	switch (sortMethod) {
	case SortMethod::InsertionSort:
		sort = &insertionSort;
		break;
	case SortMethod::QuickSort:
		sort = &quickSort;
		break;
	case SortMethod::BubbleSort:
		sort = &bubbleSort;
		break;
	}
	sort(window, size);

	// Get the middle value if the size is odd
	if (size % 2 != 0)
		return window[size / 2 + 1];

	// Or the average of the 2 middle values if the size is even
	else {
		int mid1 = window[size / 2];
		int mid2 = window[size / 2 + 1];
		return (mid1 + mid2) / 2;
	}
}
void PgmFilter::insertionSort(int*& window, int size) {

}
void PgmFilter::quickSort(int*& window, int size) {

}
void PgmFilter::bubbleSort(int*& window, int size) {

}
