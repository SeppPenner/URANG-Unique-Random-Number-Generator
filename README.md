URANG-Unique Random Number Generator
====================================

URANG-Unique Random Number Generator is an executable to generate unique numbers.
The executable was written and tested in .Net 5.0.

[![Build status](https://ci.appveyor.com/api/projects/status/8w5fj9cm9mvbsouq?svg=true)](https://ci.appveyor.com/project/SeppPenner/urang-unique-random-number-generator)
[![GitHub issues](https://img.shields.io/github/issues/SeppPenner/URANG-Unique-Random-Number-Generator.svg)](https://github.com/SeppPenner/URANG-Unique-Random-Number-Generator/issues)
[![GitHub forks](https://img.shields.io/github/forks/SeppPenner/URANG-Unique-Random-Number-Generator.svg)](https://github.com/SeppPenner/URANG-Unique-Random-Number-Generator/network)
[![GitHub stars](https://img.shields.io/github/stars/SeppPenner/URANG-Unique-Random-Number-Generator.svg)](https://github.com/SeppPenner/URANG-Unique-Random-Number-Generator/stargazers)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://raw.githubusercontent.com/SeppPenner/URANG-Unique-Random-Number-Generator/master/License.txt)
[![Known Vulnerabilities](https://snyk.io/test/github/SeppPenner/URANG-Unique-Random-Number-Generator/badge.svg)](https://snyk.io/test/github/SeppPenner/URANG-Unique-Random-Number-Generator)

## Screenshot from the executable
![Screenshot from the executable](https://github.com/SeppPenner/URANG-Unique-Random-Number-Generator/blob/master/Screenshot.JPG "Screenshot from the executable")

## How does the config need to look like
Chars is the set of chars used in the generator. See http://www.utf8-zeichentabelle.de/ for all possible chars.
Density is how much data in the database will be stored in correlation to the total possible values.
```xml
<?xml version="1.0" encoding="UTF-8" ?>
<Config xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Chars>abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_#$?!"%()[]{}+*,./:;@=^`|~²³§</Chars>
    <!-- Don't use ' or \ or < or > and else only use the following chars: http://www.utf8-zeichentabelle.de/-->
    <Density>0.55</Density>
</Config>
```

## Hint
The mechanism behind e.g. [UUIDs](https://en.wikipedia.org/wiki/Universally_unique_identifier) is a lot better and more efficient, of course.

Change history
--------------

See the [Changelog](https://github.com/SeppPenner/URANG-Unique-Random-Number-Generator/blob/master/Changelog.md).