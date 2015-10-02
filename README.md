# Group-DS

## Main.cpp
Usage: ImageFilter.exe [options] < window_size > < file_path >
* __< window_size >__  The window size to use in the watercolor-filter algorithm, required
* __< file_path >__  The path to the PGM image to be watercolor-filtered, required
* __Options:__
* -o   Show output for debugging purposes

The job of Main.cpp is to parse the command line arguments, return the appropriate error codes if any arguments were invalid,
and initiate the selected filter process if everything was entered correctly.  Command-line arguments are all passed into a 
C++ program as char arrays, so main defines some type-specific variables to hold the arguments, passes them by reference to
the loadCommLineArgs() function wherein they get set. This function returns an enum for the error state of the program, which
main then switches over.  Based on the error state, either an error message is redirected to std::cerr, or the parsed
arguments are passed to the ImageFilter class to perform the watercolor filter.  In the case of a syntax error (incorrect
number of command line arguments), the showCorrectSyntax() function is called, which displays something similar to what you
see above.  In the latter, error-free case, the runFilter() function is called.

Within loadCommLineArgs(), each possible error is checked:
* __SyntaxError__: incorrect number of command line arguments psased
* __InvalidOptionError__: an undefined command-line option was set
* __WindowSizeError__: window size was even or less than 3
* __PgmFormatError__: the image file did not have a .pgm extension
* __FileOpenError__: the image file could not be opened for whatever reason
If no errors occur, then the ErrorFree enum is returned.  The hasExtension() function is used to see if the image file had the
.pgm extension, and the chosenMethod() function is used to get the SortMethod enumeration corresponding to the user's choice.

The hasExtension() function just matches the last characters of a file path to the characters of the provided extension.
Nothing crazy.

The chosenMethod() function switches over the command line argument (if it was provided) and returns the corresponding
SortMethod enumeration.  Note that, if this argument was not passed on the command line, then insertion sort is used by default
(cause I think its usually the fastest algorithm).  If an invalid number was passed on the command line, then an error message
is displayed, but execution continues with insertion sort.

The runFilter() function passes the command line variables to the ImageFilter class, which expected type-specific arguments,
hence the need for all this validation.  The CPU clock time is recorded at the start and finish of filtering, and
used to calculate how long the operation took.  This information, along with where the filtered image was saved, is all displayed
on the console.

## ImageFilter.h
Like all class header files, ImageFilter.h just describes the interface for this class.  Its only public method is an
overloaded function called watercolor(), which can accept the file path to a PGM image either as a string or a char array (the
string overload just converts the string to a char array and calls that overload).  All the other functions are private, transparent to the calling code.

## ImageFilter.cpp
Like all class implementation files, ImageFilter.cpp defines the functions declared in ImageFilter.h.

The overloaded function called watercolor() is the only public function, which can accept the file path to a PGM image either
as a string or a char array (the string overload just converts the string to a char array and calls that overload).
This function defines variables for the width, height, maximum grey value, and pixel array stored in the PGM file.
It passes these variables by reference to the loadPgmData function, wherein the actual file is opened and the variables get set.
The variables are then passed by reference to the waterColorFilter() function, which actually scans through the 2D array of
pixel values and applies the filter.  This new pixel array is then passed by reference to the createPgm() function, which uses
the values to create a new PGM file (note that the original image is unchanged).
The new PGM will have the same name as the original PGM but with the suffix "_watercolor" applied (this is accomplished with
the renameWithSuffix() function), and will have a comment saying when it was generated (this is accomplished with the currentDateTime() function).

The loadPgmData() and createPgm() functions are pretty self explanatory.  They use ifstream and ofstream objects, respectively, and a bunch of calls to std::getline() to read data from a PGM file or write data to one.  createPgm() also takes care of deallocating the pixel array memory.

The waterColorFilter() function defines a new 2D array that will hold filtered pixel values (so the original array is unchanged).
The function loops through each row and each column of the original pixel-value array.
For each pixel:
* A new 1D array called "window" is defined and populated with all pixel values in a winSize x winSize box around the pixel
  * Note, the abstract window is a 2D array, but the actual window stored in memory is a 1D array
  * Positions that would be outside of the original pixel array are simply not added to this data structure.
* The median pixel value in the window is calculated with the median() function
* That median value is stored into the same position of the filtered pixel 2D array
Finally, the filtered values are stored back into the original array (which, remember, was passed by reference) and the
filtered pixel array's memory is deallocated.  The original array passed in thus holds the "return" values afterward.

The median() function sorts a 1D array of numbers using the quickSort() functions.  This sort
functions will accept a reference pointer to the 1D array representing the window, and sort it.  Median() assumes that after
the quickSort() is called, the window array has been sorted.  At this point, it returns the median value based on whether the window size is odd or even.
