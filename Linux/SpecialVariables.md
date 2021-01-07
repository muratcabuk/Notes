- $0 = The filename of the current script.
- $n = These variables correspond to the arguments with which a script was invoked. Here n is a positive decimal number corresponding to the position of an argument (the first argument is $1, the second argument is $2, and so on).
- $# = The number of arguments supplied to a script.
- $* = All the arguments are double quoted. If a script receives two arguments, $* is equivalent to $1 $2.
- $@ = All the arguments are individually double quoted. If a script receives two arguments, $@ is equivalent to $1 $2.
- $? = The exit status of the last command executed.
- $$ = The process number of the current shell. For shell scripts, this is the process ID under which they are executing.
- $! = The process number of the last background command.
  
 
```
> ./test.sh one two "three four"

The script:

#!/bin/bash

echo "Using \"\$*\":"
for a in "$*"; do
    echo $a;
done

echo -e "\nUsing \$*:"
for a in $*; do
    echo $a;
done

echo -e "\nUsing \"\$@\":"
for a in "$@"; do
    echo $a;
done

echo -e "\nUsing \$@:"
for a in $@; do
    echo $a;
done
```

In the first case, the parameters are regarded as one long quoted string:

```
Using "$*":
one two three four
```
Case 2 (unquoted) - the string is broken into words by the for loop:
```
Using $*:
one
two
three
four
```
Case 3 - it treats each element of $@ as a quoted string:
```
Using "$@":
one
two
three four
```
Last case - it treats each element as an unquoted string, so the last one is again split by what amounts to for three four:
```
Using $@:
one
two
three
four
```
Diğer kullanım

```
function positional_variables(){
    echo "Positional variable 1: ${1}"
    echo "Positional variable 2: ${2}"
    echo "Positional variable 3: ${3}"
}

Bash considers it unassigned:

$ positional_variables "one" "two"
Positional variable 1: one
Positional variable 2: two
Positional variable 3:

```
 
 ### Resources (Special Variables)
 
 - https://www.gnu.org/software/bash/manual/html_node/Special-Parameters.html
 - http://etutorials.org/Linux+systems/how+linux+works/Chapter+7+Introduction+to+Shell+Scripts/7.3+Special+Variables/
 - https://www.baeldung.com/linux/bash-special-variables
 - https://unix.stackexchange.com/questions/129072/whats-the-difference-between-and
 - https://www.tutorialspoint.com/unix/unix-special-variables.htm
 - https://www.bogotobogo.com/Linux/linux_shell_programming_tutorial3_special_variables.php
 - https://www.baeldung.com/linux/bash-special-variables





- IFS

```
function positional_variables(){
    IFS=";"
    echo "Positional variables with @: ${@}"
    echo "Positional variables with *: ${*}"
}
```

Now, the output is:

```
$ positional_variables "one" "two"
Positional variables with @: one two
Positional variables with *: one;two
```

IFS detaylı örnek

```
$ echo "$IFS" | cat -et
 ^I$
$
$ string="foo bar foo:bar"
$ for i in $string; do echo "[$i] extracted"; done
[foo] extracted
[bar] extracted
[foo:bar] extracted
$ IFS=":"  && echo "$IFS" | cat -et
:$
$ for i in $string; do echo "[$i] extracted"; done
[foo bar foo] extracted
[bar] extracted
$ unset IFS  && echo "$IFS" | cat -et
$
$ for i in $string; do echo "[$i] extracted"; done
[foo] extracted
[bar] extracted
[foo:bar] extracted
```




### Resources (IFS)


- https://stackoverflow.com/questions/918886/how-do-i-split-a-string-on-a-delimiter-in-bash
- https://en.wikipedia.org/wiki/Input_Field_Separators
- https://unix.stackexchange.com/questions/26784/understanding-ifs
- https://www.baeldung.com/linux/ifs-shell-variable






 
