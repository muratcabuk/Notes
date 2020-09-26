


**reset türleri**

- soft: uncommit changes, changes are left staged (index).
- mixed (default): uncommit + unstage changes, changes are left in working tree.
- hard: uncommit + unstage + delete changes, nothing left.






**güzel anlatım**

- https://www.bryanbraun.com/2019/02/23/editing-a-commit-in-an-interactive-rebase/

- https://git-rebase.io/

- https://www.freecodecamp.org/news/the-ultimate-guide-to-git-merge-and-git-rebase/

- https://www.bryanbraun.com/2019/02/23/editing-a-commit-in-an-interactive-rebase/

- https://hackernoon.com/beginners-guide-to-interactive-rebasing-346a3f9c3a6d


Use git rebase. Specifically:

1. Use git stash to store the changes you want to add.
2. Use git rebase -i HEAD~10 (or however many commits back you want to see).
3. Mark the commit in question (a0865...) for edit by changing the word pick at the start of the line into edit. Don't delete the other lines as that would delete the commits.(^vimnote)
4. Save the rebase file, and git will drop back to the shell and wait for you to fix that commit.
5. Pop the stash by using git stash pop
6. Add your file with git add <file>.
7. Amend the commit with git commit --amend --no-edit.
8. Do a git rebase --continue which will rewrite the rest of your commits against the new one.
9. Repeat from step 2 onwards if you have marked more than one commit for edit.

(^vimnote): If you are using vim then you will have to hit the Insert key to edit, then Esc and type in :wq to save the file, quit the editor, and apply the changes. Alternatively, you can configure a user-friendly git commit editor with git config --global core.editor "nano".

diğer bir teknik

To "fix" an old commit with a small change, without changing the commit message of the old commit, where OLDCOMMIT is something like 091b73a:

1. git add (my fixed files)
2. git commit --fixup=OLDCOMMIT
3. git rebase --interactive --autosquash OLDCOMMIT^

You can also use git commit --squash=OLDCOMMIT to edit the old commit message during rebase.



- https://aliozgur.gitbooks.io/git101/content/alistirmalar/Gun_10.html
- https://aliozgur.gitbooks.io/git101/content/ileri_seviye_komutlar_ve_islemler/merge_alternatifi_olarak_rebase_kullanimi.html
- https://medium.com/@halilibrahim_4325/git-merge-ve-rebasein-fark%C4%B1-nedir-1c6c81086fa9
- https://git-scm.com/docs/git-rebase



Cannot save config file 'FileBasedConfig[/home/jenkins/.config/jgit/config]' java.io.IOException: Creating directories for /home/jenkins/.config/jgit failed




**commit türleri**


- Merge commit (--no-ff) DEFAULT: Always create a new merge commit and update the target branch to it, even if the source branch is already up to date with the target branch.
- Fast-forward (--ff): If the source branch is out of date with the target branch, create a merge commit. Otherwise, update the target branch to the latest commit on the source branch.
- Fast-forward only (--ff-only): If the source branch is out of date with the target branch, reject the merge request. Otherwise, update the target branch to the latest commit on the source branch.
- Rebase, merge  (rebase + merge --no-ff): Commits from the source branch onto the target branch, creating a new non-merge commit for each incoming commit. Creates a merge commit to update the target branch. The PR branch is not modified by this operation.
- Rebase, fast-forward (rebase + merge --ff-only): Commits from the source branch onto the target branch, creating a new non-merge commit for each incoming commit. Fast-forwards the target branch with the resulting commits. The PR branch is not modified by this operation.
- Squash (--squash): Combine all commits into one new non-merge commit on the target branch.

- Squash, fast-forward only (--squash --ff-only): If the source branch is out of date with the target branch, reject the merge request. Otherwise, combine all commits into one new non-merge commit on the target branch.




