thispc
======

## Summary ##

Application to modify Windows Explorer `This PC` content in Windows 8.1 and Windows 10

## NB ##

The application modifies Local Machine in the registry so *both* Visual Studio *and* the compiled exe need to be **Run As Administrator** to function correctly.

## This PC ##

Windows 8.1 renamed Windows Explorer's `Computer` to `This PC` and added links to user `Desktop`, `Documents`, `Downloads`, `Music`, `Pictures` and `Videos` folders as shown below (with a couple of drives).

- `This PC`
  - `Desktop`
  - `Documents`
  - `Downloads`
  - `Music`
  - `Pictures`
  - `Videos`
  - `Local Disk (C:)`
  - `Local Disk (D:)`

Unfortunately no way was provided in Windows Explorer to customise whether these links appeared or not, so short of editing various registry keys you were stuck with them.

This project is an application with a simple UI to remove (and re-add) these links leaving you with a more manageable `This PC`.

- `This PC`
  - `Local Disk (C:)`
  - `Local Disk (D:)`

## Command Line ##

Can be run in "silent-mode" with (case-insensitive) `-ShowAll` or `-HideAll` parameter (`HideAll` takes priority). Still requires **Run As Adminstrator**.
