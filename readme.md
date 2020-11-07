# Euler.Net

[![Build Euler.Net](https://github.com/gorauskas/Euler.Net/workflows/Build%20Euler.Net/badge.svg?branch=master)](https://github.com/gorauskas/Euler.Net/actions)

Solutions to the Project Euler problems written in C#.

Clone this repo and then run the following from the command line:

    cd Euler.Net\Euler
    dotnet publish -c Release 
    dotnet .\bin\Debug\netcoreapp2.1\euler.dll -v -p <problem number>

## Usage

    Project Euler problems & solutions written in CSharp
    
     Usage: euler.exe [-p|-v|-V|-?]
    
      -?, -h, --help             Displays this help message and exits.
      -V                         Displays the version information and exits.
      -v                         Verbose outputs the problem statement and the
                                   solution.
      -p, --problem=VALUE        Specify the problem/solution number you want to
                                   run.
    
     Example:
      euler.exe -p 2
      euler.exe --problem=3 -v

## Tests

Alternatively, there is a full set of unit tests written with nUnit that can be
run by invoking `dotnet` at the root of the test project, like so:

    cd Euler.Net\EulerTest
    dotnet test

## How it works...

The main program in the `Program` class will try to import one of the solution
classes from the `Euler.Solutions` namespace based on the problem number passed
in via the command line. From that namespace, it will load a class called `Euler#`
where `#` is for the problem number. If the user requests verbose output, the
program calls the `Problem` property of the loaded `Euler#` class and then
calls the `Answer` property.

All `Euler#` classes are implemented using the `IEuler` common interface for all
classes. This is the key construct that allows classes to be loaded and executed
dynamically.