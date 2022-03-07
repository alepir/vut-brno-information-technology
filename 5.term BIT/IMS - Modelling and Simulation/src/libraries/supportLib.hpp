/*
* CITE: https://github.com/InductiveComputerScience/pbPlots
* LICENCE: MIT
*/

#include <vector>
#include <string>
#include <iostream>
#include <fstream>

#ifndef SUPPORT_LIB_HPP
#define SUPPORT_LIB_HPP
unsigned char *DoubleArrayToByteArray(std::vector<double> *data);
void WriteToFile(std::vector<double> *data, std::string filename);
std::vector<double> *ByteArrayToDoubleArray(std::vector<unsigned char> *data);

#endif