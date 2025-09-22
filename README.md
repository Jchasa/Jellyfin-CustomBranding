# Jellyfin Custom Logo

This plugin allows you to replace the default Jellyfin logos.

---

> [!IMPORTANT]  
> This plugin change the website logo, this might not work for apps (Like mobile or tv)

## 🛠️ Installation Steps

### Access Jellyfin Dashboard:

- Navigate to your Jellyfin server's dashboard.

### Add Plugin Repository:

1. Go to `Plugins` > `Repositories`.
2. Click on `+` to add a new repository.
3. Enter the following details:
    - Add a name
    - **URL:**
      ```
      https://raw.githubusercontent.com/jchasa/Jellyfin-CustomBranding/refs/heads/main/manifest.json
      ```
4. Click **Save**.

### Install the Plugin:

- Navigate to `Plugins` > `Catalog`.
- Find **Custom LogoBranding** in the list.
- Click **Install**.

Restart Jellyfin

---

## 🎨 Uploading Your Custom Logo

### Access Plugin Configuration:

- Go to `Plugins` > `Custom Logo`.

### Upload Logo:

- Use the provided interface to upload your custom logo image.

⚠️ Ensure the image is in **PNG format**.

- Save
---

## Troubleshooting

## The logo doesn't change
Try to clear your browsers cache

Firefox : https://support.mozilla.org/en-US/kb/how-clear-firefox-cache
Chrome : https://support.google.com/accounts/answer/32050?hl=en&co=GENIE.Platform%3DDesktop

## Know Issues
### Docker
A missing permission error occured, even when the Jellyfin user has sufficient permissions