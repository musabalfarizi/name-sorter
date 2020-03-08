# build trivial name sorter sample

top: NameSorter.exe UnitTests.exe
	mono UnitTests.exe

NameSorter.exe: NameSorter.cs
	mcs $^

UnitTests.exe: UnitTests.cs NameSorter.exe
	mcs -r:NameSorter.exe UnitTests.cs -r:/usr/lib/mono/4.5/nunit.framework.dll

Haskell:
	cabal install --only-dependencies
	cabal run name-sorter -- unsorted-names-list.txt
