#include "PictureFilter.h"
#include <string>

PictureFilter::PictureFilter() {}

// INTERFACE FUNCTIONS
void PictureFilter::watercolor(std::fstream& picture, const int winSize, SortMethod sortMethod) {
	char* lineArr;
	std::string lineStr;

	// Skip the PGM identifier on the first line
	picture.getline(lineArr, 1000);
	
	// Get the image's dimensions (skipping over any comments)
	picture.getline(lineArr, 1000);
	while (lineArr[0] == '#')
		picture.getline(lineArr, 1000);
	lineStr = lineArr;
	int spacePos = lineStr.find(' ');
	int width = std::stoi(lineStr.substr(0, spacePos - 1));
	int height = std::stoi(lineStr.substr(spacePos + 1));

	// Get the image's max greyscale value (skipping over any comments
	picture.getline(lineArr, 1000);
	while (lineArr[0] == '#')
		picture.getline(lineArr, 1000);
	int maxGrey = std::atoi(lineArr);

	// Store the actual pixel values into a 2D array
	int** pixels = new int*[height];
	for (int i = 0; i < height; ++i)
		pixels[i] = new int[width];
	while (std::getline(picture, lineStr)) {
		lineStr.
	}

	// Apply the filter to the pixel array
	watercolorFilter(pixels, width, height, winSize, sortMethod);

	// Create a new PGM file with the filtered pixel array
	std::ofstream filteredPic;
}
void PictureFilter::watercolorFilter(int** pixels, int width, int height, int winSize, SortMethod sortMethod) {
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
int PictureFilter::median(int* window, int size, SortMethod sortMethod) {
	// Sort the array
	switch (sortMethod) {
	case SortMethod::InsertionSort:
		insertionSort(window, size);
		break;
	case SortMethod::QuickSort:
		quickSort(window, size);
		break;
	case SortMethod::BubbleSort:
		bubbleSort(window, size);
		break;
	}

	// Get the middle value if the size is odd
	if (size % 2 != 0)
		return window[size / 2 + 1];
	else {
		int mid1 = window[size / 2];
		int mid2 = window[size / 2 + 1];
	}
}