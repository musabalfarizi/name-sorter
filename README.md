Trivial "Sort by Last Name" Exercise
====================================

A demonstration exercise for a simple task:

The coding assessment is just that, an assessment. The problem domain is deliberately simple, and you could very easily
write an extremely terse solution that satisfies the requirement. But our goal is not to see you implement a trivial sorting algorithm.

*  Most importantly it is to understand how your code communicates its purpose clearly and with empathy to your
potential team members. What do we mean by empathy? Empathy here is caring about how easy your code is to understand
and navigate for the next engineer who touches it.
*  Secondly it is to understand your ability to compose quality code that
adheres to SOLID (https://en.wikipedia.org/wiki/SOLID_(object-oriented_design)) principles.
* Thirdly, to see how you write tests.

So, give us your best effort, a solution of which you are proud.

## The Goal: Name Sorter

Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. A
name must have at least 1 given name and may have up to 3 given names.

## Example Usage

Given a a file called unsorted-names-list.txt containing the following list of names;

    Janet Parsons
    Vaughn Lewis
    Adonis Julius Archer
    Shelby Nathan Yoder
    Marin Alvarez
    London Lindsey
    Beau Tristan Bentley
    Leo Gardner
    Hunter Uriah Mathew Clarke
    Mikayla Lopez
    Frankie Conner Ritter

Executing the program in the following way;

    $ name-sorter ./unsorted-names-list.txt

Should result the sorted names to screen;

    Marin Alvarez
    Adonis Julius Archer
    Beau Tristan Bentley
    Hunter Uriah Mathew Clarke
    Leo Gardner
    Vaughn Lewis
    London Lindsey
    Mikayla Lopez
    Janet Parsons
    Frankie Conner Ritter
    Shelby Nathan Yoder

and a file in the working directory called sorted-names-list.txt containing the sorted names.

## Assessment Criteria

We will execute your submission against a list with a thousand names.
Your submission must meet the following criteria.
- The solution should be available for review on github.
- The names should be sorted correctly.
- It should print the sorted list of names to screen.
- It should write/overwrite the sorted list of names to a file called sorted-names-list.txt.
- Unit tests should exist.
- Minimal, practical documentation should exist.

## Awesome, but not essential criteria

- Create a build pipeline like Travis or AppVeyor that execute build and test steps.

## Submission

When you are done let us know the URL of the repo.

# Notes on This Solution

The main solution is written in C#, since this is the main language used in-house by the employer.
C# is not one of my major languages and I don't run MS-Windows so it's done with the _Mono_
environment on Gentoo Linux.  This means no Visual Studio.  I have used Visual Studio in various
work roles but I don't run MS-Windows or Studio at home.

The solution is built and run on Gentoo Linux with the command

    $ make

which runs the test in _UnitTests.cs_  This source betrays the one thing I couldn't get working:  the _NUnit_ unit
testing framework.  There should not be a _Main_ in _class NameSorterTests_.  Despite asking [here](https://forums.gentoo.org/viewtopic-t-1090080-highlight-.html?sid=057d814902fc0ab407690fc451d44c4a)
and [here](https://forums.gentoo.org/viewtopic-t-1090046-highlight-.html?sid=057d814902fc0ab407690fc451d44c4a) in
the Gentoo forums, as well as on [Stack Overflow](https://stackoverflow.com/questions/53568257/why-does-nunit-ignore-the-tests-in-my-c-sharp-source/53568783),
I couldn't resolve this issue.

The solution nevertheless does satisfy all the essential criteria.


## The Other Solution

Just for something different, I implemented the solution in Haskell as well.  The comparative brevity is remarkable:
just thirteen lines of source.  See _Main.hs_.
Although I've used a fair amount of higher-order programming, I resisted the urge to use [point-free](https://pointfree.io)
programming throughout, as the solution is supposed to be realistic rather than a show-case for
over-cleverness.
