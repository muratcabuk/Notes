## HereDoc nedir?

When writing shell scripts you may be in a situation where you need to pass a multiline block of text or code to an interactive command, such as tee , cat, or sftp .


In Bash and other shells like Zsh, a Here document (Heredoc) is a type of redirection that allows you to pass multiple lines of input to a command.


The syntax of writing HereDoc takes the following form:


```
[COMMAND] <<[-] 'DELIMITER'
  HERE-DOCUMENT
DELIMITER

```

- The first line starts with an optional command followed by the special redirection operator << and the delimiting identifier.
 - You can use any string as a delimiting identifier, the most commonly used are EOF or END.
 - If the delimiting identifier is unquoted, the shell will substitute all variables, commands and special characters before passing the here-document lines to the command.
 - Appending a minus sign to the redirection operator <<-, will cause all leading tab characters to be ignored. This allows you to use indentation when writing here-documents in shell scripts. Leading whitespace characters are not allowed, only tab.
- The here-document block can contain strings, variables, commands and any other type of input.
- The last line ends with the delimiting identifier. White space in front of the delimiter is not allowed.

```
cat << EOF
The current working directory is: $PWD
You are logged in as: $(whoami)
EOF
```
If you are using a heredoc inside a statement or loop, use the <<- redirection operation that allows you to indent your code.

```
if true; then
    cat <<- EOF
    Line with a leading tab.
    EOF
fi

```

Instead of displaying the output on the screen you can redirect it to a file using the >, >> operators.

```
cat << EOF > file.txt
The current working directory is: $PWD
You are logged in as: $(whoami)
EOF
```

If the file.txt doesn’t exist it will be created. When using > the file will be overwritten, while the >> will append the output to the file.

The heredoc input can also be piped. In the following example the sed command will replace all instances of the l character with e:

```
cat <<'EOF' |  sed 's/l/e/g'
Hello
World
EOF
```

To write the piped data to a file:

```
cat <<'EOF' |  sed 's/l/e/g' > file.txt
Hello
World
EOF

```

#### Resources
- https://linuxize.com/post/bash-heredoc/



## Cat

```
$ cat --help

Usage: cat [OPTION]... [FILE]...
Concatenate FILE(s) to standard output.

With no FILE, or when FILE is -, read standard input.

  -A, --show-all           equivalent to -vET
  -b, --number-nonblank    number nonempty output lines, overrides -n
  -e                       equivalent to -vE
  -E, --show-ends          display $ at end of each line
  -n, --number             number all output lines
  -s, --squeeze-blank      suppress repeated empty output lines
  -t                       equivalent to -vT
  -T, --show-tabs          display TAB characters as ^I
  -u                       (ignored)
  -v, --show-nonprinting   use ^ and M- notation, except for LFD and TAB
      --help     display this help and exit
      --version  output version information and exit

Examples:
  cat f - g  Output f's contents, then standard input, then g's contents.
  cat        Copy standard input to standard output.

GNU coreutils online help: <https://www.gnu.org/software/coreutils/>
Full documentation at: <https://www.gnu.org/software/coreutils/cat>
or available locally via: info '(coreutils) cat invocation'
 
```

https://snipcademy.com/linux-command-line-text-processing



#### Resources
- https://linuxize.com/post/linux-cat-command/
- https://ceaksan.com/tr/cat-komutu-ve-kullanimi
- https://yazilim.aykutasil.com/bash-scripts/





## Tee

https://linuxize.com/post/linux-tee-command/





#### Resources

