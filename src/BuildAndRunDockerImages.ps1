#!/usr/bin/env pwsh

<#
.SYNOPSIS
This script builds all the docker images.
#>

$ErrorActionPreference = "Stop"

function Main
{
    if ($null -eq (Get-Command "docker" -ErrorAction SilentlyContinue))
    {
        throw "Unable to find docker in your PATH"
    }

    Set-Location (Split-Path -Parent $PSScriptRoot)

    ##
    # AasxServerBlazor
    ##
    
    $imageTag = "aasx-server-blazor-for-demo"
    Write-Host "Building the docker image: $imageTag"
    docker build `
        -t $imageTag `
        -f src/docker/Dockerfile-AasxServerBlazor-240205 `
        .
    
    Write-Host "The image $imageTag has been built."

    docker run `
        -p 5001:5001 `
        --name aasx-server-blazor-test `
        $imageTag `
        .
}

$previousLocation = Get-Location
try
{
    Main
}
finally
{
    Set-Location $previousLocation
}
