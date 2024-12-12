# Titan.API

- [Titan.API](#titanapi)
  - [Overview](#overview)
  - [Features](#features)
  - [Requirements for deployment](#requirements-for-deployment)
  - [Build instructions](#build-instructions)

## Overview
Titan API is a backend service designed to provide strong APIs for interacting with **TrinityCore**, the main goal is to provide
tools and services that simplify managing game servers, players, and data. **It is still work-in-progress and a lot of features are missing.**


## Features

* **Extensibility** : The architecture is quite modular, which facilitates new features integration.
* **Cross-Platform** : Can be deployed on any platform supported by .NET Core.
* **Master branch target** : Designed to work with **TrinityCore** master branch.

## Requirements for deployment
Titan is built with .NET Core 9.0, in order to compile it and using it, you have to download the SDK, here is the link [.NET SDK](https://dotnet.microsoft.com/download)

## Build instructions

1. Clone the repository.

```sh
git clone https://github.com/helnesis/TitanAPI.git
```

2. Go to the project directory, builds the project through your favorite IDE or with

```sh
dotnet build
```

