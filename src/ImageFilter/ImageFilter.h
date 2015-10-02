#ifndef H_PGM_FILTER
#define H_PGM_FILTER

#include <string>

class ImageFilter {
	// CONSTRUCTORS
public:
	ImageFilter();
	ImageFilter(std::string, bool = false);

public:
	// INTERFACE
	std::string filePath;
	bool showOutput;
	const char* watercolor(const int);

private:
	// FILE MANIPULATION FUNCTIONS
	void loadPgmData(const char*, int&, int&, int&, int**&);
	const char* createPgm(const char*, int, int, int, int**&);
	const char* renameWithSuffix(const char*, const std::string&);

	// FILTER ALGORITHM FUNCTIONS
	void watercolorFilter(int**&, int, int, int);

	// HELPER FUNCTIONS
	void reset(std::string, bool);
	const char* currentTimeStr();
	void swap(int*, int*);
	int median(int*, int);
	void quickSort(int*&, int);
	void quickSortRecurs(int*, int, int);
};

#endif