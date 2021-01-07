 - exec
 
The exec built-in command mirrors functions in the kernel, there are a family of them based on execve, which is usually called from C.


exec replaces the current program in the current process, without forking a new process. It is not something you would use in every script you write, but it comes in handy on occasion. 


exec replaces the current shell with a new program. Thus, exec $SHELL replaces the shell with a completely new instance of the program specified in the variable named SHELL. 

exec command in Linux is used to execute a command from the bash itself. This command does not create a new process it just replaces the bash with the command to be executed. If the exec command is successful, it does not return to the calling process.

```
bash-3.2$ bash
bash-3.2$ exec > file
bash-3.2$ date
bash-3.2$ exit
bash-3.2$ cat file
Thu 18 Sep 2014 23:56:25 CEST
```



In wrapper script

exec is used mainly in wrapper scripts.

If you want to modify the environment for a program before executing the main program, you'd often write an script and at the end of it start the main program. But there is no need for the script to stay in memory at that time. So, exec is used in these cases so that, the main program can replace the mother script.

Here is a practical example of it. It's mate-terminal.wrapper script comes with mate-terminal. It starts the mate-terminal with some extra arguments by checking user's environments.

#!/usr/bin/perl -w

my $login=0;

while ($opt = shift(@ARGV))
{
    if ($opt eq '-display')
    {
        $ENV{'DISPLAY'} = shift(@ARGV);
    }
    elsif ($opt eq '-name')
    {
        $arg = shift(@ARGV);
        push(@args, "--window-with-profile=$arg");
    }
    elsif ($opt eq '-n')
    {
        # Accept but ignore
        print STDERR "$0: to set an icon, please use -name <profile> and set a profile icon\n"
    }
    elsif ($opt eq '-T' || $opt eq '-title')
    {
        push(@args, '-t', shift(@ARGV));
    }
    elsif ($opt eq '-ls')
    {
        $login = 1;
    }
    elsif ($opt eq '+ls')
    {
        $login = 0;
    }
    elsif ($opt eq '-geometry')
    {
        $arg = shift(@ARGV);
        push(@args, "--geometry=$arg");
    }
    elsif ($opt eq '-fn')
    {
        $arg = shift(@ARGV);
        push(@args, "--font=$arg");
    }
    elsif ($opt eq '-fg')
    {
        $arg = shift(@ARGV);
        push(@args, "--foreground=$arg");
    }
    elsif ($opt eq '-bg')
    {
        $arg = shift(@ARGV);
        push(@args, "--background=$arg");
    }
    elsif ($opt eq '-tn')
    {
       $arg = shift(@ARGV);
       push(@args, "--termname=$arg");
    }
    elsif ($opt eq '-e')
    {
        $arg = shift(@ARGV);
        if (@ARGV)
        {
            push(@args, '-x', $arg, @ARGV);
            last;
        }
        else
        {
            push(@args, '-e', $arg);
        }
        last;
    }
    elsif ($opt eq '-h' || $opt eq '--help')
    {
        push(@args, '--help');
    }
}
if ($login == 1)
{
    @args = ('--login', @args);
}
exec('mate-terminal',@args);

The point to notice here is, there is an exec call, which replaces this script in memory.

Here is a similar question answered in Unix & Linux StackExchange Site - https://unix.stackexchange.com/q/270929/19288
To redirect file-descriptors

Another common use of exec is in redirecting file-descriptors. stdin, stdout, stderr can be redirected to files using exec.

- Redirecting stdout - exec 1>file will cause the standard output to be a file named file for the end of the current shell session. Anything to output to the display will be in the file.

- Redirecting stdin - It can also be used to redirect the stdin to a file. For example, If you want to execute a script file script.sh, you can just redirect the stdin to the file using exec 0 < script.sh







### Resources

- https://askubuntu.com/questions/819910/what-are-possible-use-of-exec-command
- https://askubuntu.com/questions/525767/what-does-an-exec-command-do
