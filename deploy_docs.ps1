cd Documentation/Help
git config --global user.email $env:APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL
git config --global user.name $env:APPVEYOR_REPO_COMMIT_AUTHOR
git clone --branch=gh-pages https://www.github.com/mcnultyyy/SkeletonMvc gh-pages
git add .
$message = "CI autocommit from commit "+$env:APPVEYOR_REPO_COMMIT;
git commit -m $message