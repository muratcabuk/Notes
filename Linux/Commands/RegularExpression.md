### POSIX Basic vs Extented Regular Expression

- **Basic Regular Expression (BRE):** şunlar özel karakterdir :  ^ $ . [ ] *
- **Extented Regular Expressions (ERE):** şuanlar BRE ye ek olarak eklenmiştir : ( ) { } ? + |

ileride örnekler olacak

### The Anchor Characters: ^ and $

 "^" karakteir başlangıç, ve "$" karakteri de bitiş anchor olark kullanılır.
 
 örnek kullanımlar
 
 ```
  Pattern       Matches
 
   ^A          "A" at the beginning of a line
   A$          "A" at the end of a line
   A^          "A^" anywhere on a line
   $A          "$A" anywhere on a line
   ^^          "^" at the beginning of a line
   $$          "$" at the end of a line
```

örneğin merhaba ile başlayan kelimeleri yakalamak için

```
$ echo "merhaba 0 bugün 1 nasılsın? 2 kötü 3 görünüyorsun" | grep -no  ^mer[a-z]*

1:merhaba

```
sonu "yorsun." ile biten satırlar.

```
$ echo "merhaba 0 bugün 1 nasılsın? 2 kötü 3 görünüyorsun." | grep -no  "[a-z]*yorsun.$"

#sonuç
1:görünüyorsun.

```

### Match any character with . - Nokta Karakteri

The character "." is one of those special meta-characters. By itself it will match any character, except the end-of-line character. The pattern that will match a line with a single characters is

```
$ echo "merhaba 0 bugün 1 nasılsın? 2 kötü 3 görünüyorsun." | grep -no  "^."
#Sonuç
1:m

```

### Specifying a Range of Characters with [...] - Aralık Belirtme

alttaki ki kullanım da aynıdır.

```
^[0123456789]$

^[0-9]$

```
örnek

```
$ echo "merhaba 0 bugün 1 nasılsın? 2 kötü 3 görünüyorsun." | grep -no  "[0123456789]"

#sonuç
1:0
1:1
1:2
1:3

```
aynı şekilde

```
$ echo "merhaba 0 bugün 1 nasılsın? 2 kötü 3 görünüyorsun." | grep -no  "[0-9]"

#sonuç
1:0
1:1
1:2
1:3

```

### Exceptions in a character set - İstisna Berlirtmek

```
Regular Expression     Matches
    []                  The characters "[]"
    [0]                 The character "0"
    [0-9]               Any number
    [^0-9]              Any character other than a number
    [-0-9]              Any number or a "-"
    [0-9-]              Any number or a "-"
    [^-0-9]             Any character except a number or a "-"
    []0-9]              Any number or a "]"
    [0-9]]              Any number followed by a "]"
    [0-9-z]             Any number, or any character between "9" and "z".
    [0-9\-a\]]          Any number, o a "-", a "a", or a "]"

```

### Repeating character sets with * - karakter tekrarı


örnekler daha iyi anlatacaktır.

```
$  echo "merhaba 0 bugün 1 nasılsın? 234 kötü 3 görünüyorsun." | grep -no  "[0-9]*"
1:0
1:1
1:234
1:3
```

eğer * karakterini kullanmasaydık

```
$ echo "merhaba 0 bugün 1 nasılsın? 234 kötü 3 görünüyorsun." | grep -no  "[0-9]"
1:0
1:1
1:2
1:3
1:4
1:3

```

### Matching a specific number of sets with \{ and \} = maksimum benzerlik belirtmek

"<," ">," "{," "}," "(," ")," veya rakamdan önce backslash kullanılırsa özel kullanımıa girmiş olur. 


aşağıdaki süslü parantezler içinde ilk rakam min ikinci max olanı ifade eder. 

```
Regular Expression  Matches
_
* 	                Any line with an asterisk
\* 	                Any line with an asterisk
\\ 	                Any line with a backslash
^* 	                Any line starting with an asterisk
^A* 	            Any line
^A\* 	            Any line starting with an "A*"
^AA* 	            Any line if it starts with one "A"
^AA*B 	            Any line with one or more "A"'s followed by a "B"
^A\{4,8\}B 	        Any line starting with 4, 5, 6, 7 or 8 "A"'s
                    followed by a "B"
^A\{4,\}B 	        Any line starting with 4 or more "A"'s
                    followed by a "B"
^A\{4\}B 	        Any line starting with "AAAAB"
\{4,8\} 	        Any line with "{4,8}"
A{4,8} 	            Any line with "A{4,8}"

```

Örneğin en az 3 en fazla 5 tane b harfi geçen kelimeleri

```
$ echo "merhaba 0 bugün 1 nasılsın? 234 kötü 3 görünüyorsun. aaaa 1234567 bbbb b bbbbbb bbbbbbb" | egrep -no  b\{3,5}
1:bbbb
1:bbbbb
1:bbbbb
```

### \<\> Kullanara, Başlangıç ve Bitiş belirterek kelime eşleştrime


Searching for a word isn't quite as simple as it at first appears. The string "the" will match the word "other". You can put spaces before and after the letters and use this regular expression: " the ". However, this does not match words at the beginning or end of the line. And it does not match the case where there is a punctuation mark after the word.

There is an easy solution. The characters "\<" and "\>" are similar to the "^" and "$" anchors, as they don't occupy a position of a character. They do "anchor" the expression between to only match if it is on a word boundary. The pattern to search for the word "the" would be "\<[tT]he\>". The character before the "t" must be either a new line character, or anything except a letter, number, or underscore. The character after the "e" must also be a character other than a number, letter, or underscore or it could be the end of line character. 


örnekler

```
$ echo "merhaba 0 bugün 1 nasılsın? 234 kötü 3 görünüyorsun" | egrep -no "\<.ugü.\>"
1:bugün

```

```
$ echo "merhaba 0 bugün 1 nasılsın? 234 kötü 3 görünüyorsun" | egrep -no "\<kötü\>"
1:kötü
```


### () ile tekrarlayan regular expressionlar (Back References)

(|) pipe ile birlikte kullanılırsa iki pattern seçimi de yapılabilir.

örnekler


```
$ echo "01 Merhaba bugün 30.12.2020 Nasılsin? iyi Görünmüyorsun yarın 01/01/2021 02/02/2021 02.02.2024 " | egrep -no '(01|30)((\.|/)(0[1-9]{1}|[10-12]{2})(\.|/))(2020|2021)'

1:30.12.2020
1:01/01/2021

```

### POSIX character sets

POSIX added newer and more portable ways to search for character sets. Instead of using [a-zA-Z] you can replace 'a-zA-Z' with [:alpha:], or to be more complete. replace [a-zA-Z] with [[:alpha:]]. The advantage is that this will match international character sets. You can mix the old style and new POSIX styles, such as

grep '[1-9[:alpha:]]'

Here is the fill list


```
Character Group 	Meaning
[:alnum:] 	         Alphanumeric
[:cntrl:] 	         Control Character
[:lower:] 	         Lower case character
[:space:] 	         Whitespace
[:alpha:] 	         Alphabetic
[:digit:] 	         Digit
[:print:] 	         Printable character
[:upper:] 	         Upper Case Character
[:blank:] 	         whitespace, tabs, etc.
[:graph:] 	         Printable and visible characters
[:punct:] 	         Punctuation
[:xdigit:] 	         Extended Digit
```
Note that some people use [[:alpha:]] as a notation, but the outer '[...]' specifies a character set. 

örnek

```
$ echo "01 Merhaba bugün 30.12.2020 Nasılsin? iyi Görünmüyorsun yarın 01/01/2021 02/02/2021 02.02.2024 " | egrep -no [[:alpha:]]{5}
1:Merha
1:bugün
1:Nasıl
1:Görün
1:müyor
1:yarın

```
yada

```
$ echo "01 Merhaba bugün 30.12.2020 Nasılsin? iyi Görünmüyorsun yarın 01/01/2021 02/02/2021 02.02.2024 " | egrep -no [[:digit:]]{3}
1:202
1:202
1:202
1:202


````


### Resources

- https://likegeeks.com/regex-tutorial-linux/
- https://www.digitalocean.com/community/tutorials/using-grep-regular-expressions-to-search-for-text-patterns-in-linux
- https://pubs.opengroup.org/onlinepubs/7908799/xbd/re.html
- https://en.wikibooks.org/wiki/Regular_Expressions/POSIX-Extended_Regular_Expressions
- https://www.gnu.org/software/sed/manual/html_node/BRE-vs-ERE.html
- https://linuxreviews.org/Tao_of_Regular_Expressions
- https://unbounded.systems/blog/3-kinds-of-parentheses-are-you-a-regex-master/
