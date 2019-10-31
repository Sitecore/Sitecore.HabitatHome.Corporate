# Habitat Home Corporate

## Introduction

Habitat Home Corporate Site and the tools and processes in it, is a Sitecore&reg; solution **example built using standard Sitecore MVC** on the Sitecore Experience Platform&trade; (XP) following the Helix architecture principles.

- [Important notice](#important-notice)
- [Getting Started](#getting-started)
- [Contribute or issues](#contribute-or-issues)

## Important Notice

### Is Habitat Home Corporate a starter kit or template solution

No. You should not clone this repository for the purposes of starting a new Sitecore project. There are other community solutions which can be used as a starter for Helix-based Sitecore implementations. Habitat Home Corporate is intended as a **demo site demonstrating the basic Sitecore platform capabilities**.

### Is Habitat Home Corporate supported by Sitecore

Sitecore maintains the Habitat Home Corporate example, but Habitat Home Corporate code is not supported by Sitecore Product Support Services. ***Please do not submit support tickets regarding Habitat Home Corporate***.

### Warranty

The code, samples and/or solutions provided in this repository are for example purposes only and without warranty (expressed or implied). The code has not been extensively tested and is not guaranteed to be bug free.

## Getting started

### Prerequisites

#### Sitecore Experience Platform

The latest Habitat Home Corporate site is built to support the following version of the Sitecore Experience Platform: ***Sitecore Experience Platform 9.2 Initial release***

In order to install the latest version of Sitecore that works with the Habitat Home Corporate site, **[you need to head over to the Sitecore.HabitatHome.Utilities repository](https://github.com/Sitecore/Sitecore.HabitatHome.Utilities)** and follow the instructions there. The Sitecore.HabitatHome.Utilities repository is a collection of useful utilities and script examples to help in the context of the Habitat Home demos, of which one is this Habitat Home Corporate site.

**Note:** You should skip the `.\install-modules` step in the Utilities repository. Habitat Home Corporate does not require the Sitecore Powershell Extensions or Sitecore Experience Accelerator modules.

#### URL Rewrite module

As part of the Habitat Home Corporate installation, an IIS URL rewrite rule is added to the web.config file in order to enforce HTTPS requests on the website. Please ensure you have the [URL Rewrite module](https://www.iis.net/downloads/microsoft/url-rewrite) installed or you will receive a 500.19 error after deployment.

### Deployment

1. Open an elevated (run as admin) PowerShell terminal at the root of your working copy.
2. Deployment of the Habitat Home Corporate demo can be done using either:
    - Unicorn

      Run `.\build.ps1`

## Contribute or Issues

Please **post any issues on the Slack Community #habitathome channel** or **create an issue on GitHub**.

Contributions are always welcome!
