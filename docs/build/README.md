# Deployment Options

## Deploying locally with Docker

### Docker Deployment Known Issues

- xConnect is currently not working (throwing xConnect model errors)
- Need to manually run "Populate Solr Managed Schemas" in the Control Panel before Solr indexing works

### Docker Deployment Prerequisites

- Sitecore base images built (either locally or in a registry)
  - see [Docker-Images Repo](https://github.com/sitecore/docker-images) for more details
- Windows version 1809 or later
- Docker (Engine) for Windows version 19.03 or later
- "az" PowerShell module
  - [https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest)

### Starting up your Sitecore instance

- Ensure your Sitecore license is in `c:\license`
- Modify .env file:
  - `REGISTRY`: set your registry url (trailing slash (/) is important).
  - `REMOTEDEBUGGER_PATH`: Ensure the path is valid. You might have to change `Enterprise` to `Professional` or `Community`.
- Set the SA password to the one configured in your base image
- login to your docker registry
  - for Azure ACR:
    - `az login`
    - `az acr login --name <registryname>`
- run `docker-compose up -d`
  - this will pull all of the necessary base images and spin up your Sitecore environment. It will take **quite some time** if this is the first time you execute it.

### Deploying to Docker

- Confirm that you can access the Sitecore instance deployed using docker-compose in the previous step by browsing to [http://127.0.0.1:44101/sitecore](http://127.0.0.1:44101/sitecore) which is the default endpoint for the CM role specified in the docker-compose.yml file. Ensure you replace it with your own value if you changed it!

**DEPLOY with Unicorn**

- Review the `cake-config.json` file if you've made any changes to the endpoints or if you need to change the default settings.

`.\build.ps1 -Target Docker-Unicorn`
