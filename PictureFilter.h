#ifndef H_PICTURE_FILTER
#define H_PICTURE_FILTER

#include <fstream>
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
	static void createPgm(const char*, int, int, int, int**&);
	static const char* renameWithSuffix(const char*, const std::string&);
	static void watercolorFilter(int**, int, int, int, SortMethod);
	static int median(int*, int, SortMethod);
	static void insertionSort(int*&, int);
	static void quickSort(int*&, int);
	static void bubbleSort(int*&, int);
};

#endif