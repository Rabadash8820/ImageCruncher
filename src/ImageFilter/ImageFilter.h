#ifndef H_PGM_FILTER
#define H_PGM_FILTER

#include <string>

class PgmFilter {
public:
	// ENUMERATIONS
	enum class SortMethod {
		QuickSort,
		InsertionSort,
		BubbleSort
	};

protected:
	// PROTECTED CONSTRUCTOR
	PgmFilter();

public:
	// INTERFACE FUNCTIONS
	static const char* watercolor(const std::string&, const int, SortMethod);
	static const char* watercolor(const char*, const int, SortMethod);

private:
	// FILE MANIPULATION FUNCTIONS
	static void loadPgmData(const char*, int&, int&, int&, int**&);
	static const char* createPgm(const char*, int, int, int, int**&);
	static const char* renameWithSuffix(const char*, const std::string&);
	static const char* currentTimeStr();

	// FILTER ALGORITHM FUNCTIONS
	static void watercolorFilter(int**&, int, int, int, SortMethod);
	static int median(int*, int, SortMethod);
	static void insertionSort(int*&, int);
	static void quickSort(int*&, int);
	static void bubbleSort(int*&, int);
	static void quickSortRecurs(int*, int, int);
	static void swap(int*, int*);
};

#endif