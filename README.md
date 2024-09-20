# XrmToolbox Dataverse Anonymizer tool

This XrmToolbox tool enables you to easily anonymize data in a Dataverse environment.
You can choose the fields you want to anonymize and replace their value with either a defined sequence, random or fake data generated by the [Bogus](https://github.com/bchavez/Bogus) library.

It's especially useful when you need to create a copy of a production environment for testing, development, training or demo purposes, but you need to replace sensitive data with fake data.

Using data generated by the Bogus library, you can create fake data that looks real, but it's not. You can also define a sequence of values to replace the original data.

![Screenshot](https://github.com/kowgli/XrmToolBox.DataverseAnonymizer/blob/master/Docs/DDA_Screenshot.png?raw=true)

# Version history

## 0.5 (2024-09-20)
- Fixed critical bugs in on-premise environments. Tested in version 9.1. Older version not confirmed.

## 0.4 (2024-04-14)
- Added support for aditional data types: whole number, float, decimal, currency and dates.
- Fixed minor bugs. 

## 0.3 (2024-02-23)
- Added multi-threaded execution.

## 0.2 (2024-02-21)
- Added save/load functionality.
- Minor usability improvements.

## 0.1 (2024-02-18)
- Initial release.