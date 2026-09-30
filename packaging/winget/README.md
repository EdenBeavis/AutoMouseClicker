# WinGet Release Preparation

The root `VERSION` file is the source of truth for stable releases. A fixed GitHub Release contains `AutoMouseClicker.exe`, `AutoMouseClicker.exe.sha256`, and a generated `EdenBeavis.AutoMouseClicker.yaml` WinGet manifest. The manifest is generated from the exact binary and checksum for that release.

## Create a Release

Ordinary pushes to `main` continue to update the rolling release. To publish a stable release, change `VERSION` to the next unused `MAJOR.MINOR.PATCH` value in the release-ready change. For example, after `1.0.0`, set it to `1.0.1`:

```powershell
Set-Content VERSION '1.0.1'
git add VERSION
git commit -m "Bump version to 1.0.1"
git push origin main
```

In a pull-request workflow, include the `VERSION` change in the release PR and merge it to `main`. GitHub Actions compares the file's version with the highest versioned release: the same version skips stable publishing, a higher version creates the release and its `v` tag, and a lower version fails. No manual Git tag or GitHub Release is needed. The rolling release remains the latest build from `main` and must not be used in a WinGet manifest.

## Submit to WinGet

For the initial package, submit the generated manifest to the `microsoft/winget-pkgs` community repository and wait for the PR to merge. The project uses the MIT License, and the manifest identifies it as MIT with a link to the repository's `LICENSE` file.

For subsequent tagged releases, the workflow submits the update automatically when the `WINGET_CREATE_GITHUB_TOKEN` repository secret is configured. Create a GitHub personal access token (classic) with the `public_repo` scope, then add it under **Settings > Secrets and variables > Actions** as `WINGET_CREATE_GITHUB_TOKEN`. Do not add the secret until the initial package is accepted; otherwise the update command cannot find the package in the community repository. If the secret is absent, releases still publish normally and the WinGet step is skipped with a workflow notice.

A checksum verifies that a download matches the release asset; it does not identify the publisher or remove Windows SmartScreen warnings.