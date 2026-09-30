# WinGet Release Preparation

Version tags create fixed GitHub Releases containing `AutoMouseClicker.exe`, `AutoMouseClicker.exe.sha256`, and a generated `EdenBeavis.AutoMouseClicker.yaml` WinGet manifest. The manifest is generated from the exact binary and checksum for that release. Do not move or reuse a published version tag; WinGet manifests pin both the version-specific download URL and its checksum.

## Create a Release

Pushing to `main` updates only the rolling release. After the release changes are merged and `main` is at the intended release commit, create and push the version tag separately:

```powershell
git switch main
git pull
git tag -a v1.0.0 -m "AutoMouseClicker 1.0.0"
git push origin v1.0.0
```

Pushing the tag triggers GitHub Actions to publish the versioned release, checksum, and WinGet manifest. Do not create the GitHub Release manually; the workflow creates it. The existing `rolling` release continues to track `main` and must not be used in a WinGet manifest.

## Submit to WinGet

The project uses the MIT License, and the generated manifest identifies it as MIT with a link to the repository's `LICENSE` file. After a versioned release is published, download its manifest asset, confirm the package identifier `EdenBeavis.AutoMouseClicker` is available, validate the manifest with WinGet's validation tooling, and submit it to the `microsoft/winget-pkgs` community repository for review. Microsoft's manifest creator can guide the submission process.

A checksum verifies that a download matches the release asset; it does not identify the publisher or remove Windows SmartScreen warnings.