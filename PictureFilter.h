#ifndef H_PICTURE_FILTER
#define H_PICTURE_FILTER

#include <fstream>
#include <string>

class PictureFilter {
public:
	// ENUMERATIONS
	enum class SortMethod {
		QuickSort,
		InsertionSort,
		BubbleSort
	};

protected:
	// PROTECTED CONSTRUCTOR
	PictureFilter();

public:
	// INTERFACE FUNCTIONS
	static void watercolor(const std::string&, const int, SortMethod);
	static void watercolor(const char*, const int, SortMethod);

private:
	//HElPER FUNCTIONS
	static void watercolorFilter(int**, int, int, int, SortMethod);
	static int median(int*, int, SortMethod);
	static void insertionSort(int*, int);
	static void quickSort(int*, int);
	static void bubbleSort(int*, int);
};

#endif