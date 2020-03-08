module Main where

{-
Minimal solution to a trivial sort-by-surname-major exercise.

This is a supplementary to the solution in C#.
-}

-- Import the required functions:
import System.Environment (getArgs)
import Data.Sort (sortOn)
import Data.List (words, last, init)
import System.IO (withFile, IOMode(..), hPutStrLn)

-- | REPL:  command-line to standard output.
	-- 1 Get command line arguments as a string list
main = getArgs
	-- 2 Extract the first argument (assume non-empty list)
	--   and return (lazily) the contents of the file of that
	--   name;  assuming it exists -- no error checking.
	>>= readFile . head
	-- 3 Break the contents into lines and sort each by its
	--   last-name-first form, as computed by lastNameMajor.
	--   See http://hackage.haskell.org/package/sort-1.0.0.0/docs/Data-Sort.html
	--   Finally, send it to the special-purpose outputting function
	>>= doubleOutput . sortOn lastNameMajor . lines


-- | Send the list of strings to both the named file and to standard output
doubleOutput names = withFile "sorted-names-list.txt" WriteMode send where
	send handle = mapM_ putAndReturn names where
		putAndReturn s = hPutStrLn handle s >> putStrLn s


-- | "first second third ... last" -> [ "last", "first", "second", "third", "..." ]
-- It takes a String argument and returns a list of String
-- and the list of String is used as the sorting key.
lastNameMajor = theLastWillBeFirst . words


-- | Put the last element of the list at the front:
-- [ "first", "second", "third", "...", "last" ] -> [ "last", "first", "second", "third", "..." ]
theLastWillBeFirst names = last names : init names
