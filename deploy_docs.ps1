cd Documentation
git config --global credential.helper store
git config --global core.autocrlf true
Add-Content "$env:USERPROFILE\.git-credentials" "https://$($env:GH_TOKEN):x-oauth-basic@github.com`n"
git config --global user.email $env:APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL
git config --global user.name $env:APPVEYOR_REPO_COMMIT_AUTHOR
git config --global push.default simple
git clone --branch=gh-pages https://www.github.com/mcnultyyy/SkeletonMvc gh-pages
Copy-Item -Path .\Help\* -Destination .\gh-pages\ -Recurse -Force
cd gh-pages
git add .
Set-Variable message ([string]::Format("CI docs deployment from commit {0}", $env:APPVEYOR_REPO_COMMIT))
git commit -m $message
git push