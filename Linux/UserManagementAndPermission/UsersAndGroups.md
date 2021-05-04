### Useful Commands

check home directory : grep hadoopuser /etc/passwd | cut -d ":" -f6

create symblink : ln -fs target-path source-path-and-filename

get all symb links : find ./ -type l

get real path symb link : readlink -f [sybmlynk name]

see all users : nano /etc/users

see all groups: nano /etc/groups

see diectory permission: ls -ld /foldername

see user detail : id username

run program on terminal without log (e.g vs code) : code &

run program on terminal without log (e.g vs code) if we already open termianal, just change the session : setsid program-name &>/dev/null


