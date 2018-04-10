- git checkout <branch>
    - moves HEAD to different branch
    - working area and index are updated as well
- git add <filename>
    - sends files from working area to index
- git rm <filename>
    - deletes files from **both** the working area and the repository
- git rm --cached <filename>
    - **opposite of add**
    - removes file from index, but keeps it in working area
- git commit
    - sends files from index to repository


Moving and Renaming
- Option 1
    - git mv <old filename> <new filename>
    - git add <new filename>
    - git add <old filename>
    - The old filename will show as deleted in the git status and the new file has been added
    - By doing a 'git add' we update the index with the appropriate file content


Git Reset
- reset does different things in different contexts
- git reset <commit> 
    - moves the branch (and HEAD along with it) to point to that specific commit
- git reset --hard
    - copies files from repository to BOTH working area and index, overwriting any changes
- git reset --mixed (default option)
    - copies file from repo to JUST the index, overwriting any changes, but leaving the working area alone
- git reset --soft
    - Don't do anything to working area and index

Commands that move branches
- commit
- merge
- rebase
- pull

