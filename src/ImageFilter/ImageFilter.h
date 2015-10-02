#ifndef H_PGM_FILTER
#define H_PGM_FILTER

#include <string>

class ImageFilter {
protected:
	// PROTECTED CONSTRUCTOR
	ImageFilter();

public:
	// INTERFACE FUNCTIONS
	static const char* watercolor(const std::string&, const int);
	static const char* watercolor(const char*, const int);

private:
	// FILE MANIPULATION FUNCTIONS
	static void loadPgmData(const char*, int&, int&, int&, int**&);
	static const char* createPgm(const char*, int, int, int, int**&);
	static const char* renameWithSuffix(const char*, const std::string&);
	static const char* currentTimeStr();

	// FILTER ALGORITHM FUNCTIONS
	static void watercolorFilter(int**&, int, int, int);
	static int median(int*, int);
	static void insertionSort(int*&, int);
	static void quickSort(int*&, int);
	static void bubbleSort(int*&, int);
	static void quickSortRecurs(int*, int, int);
	static void swap(int*, int*);
};

#endif