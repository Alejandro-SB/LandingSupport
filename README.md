# LandingSupport

## Summary
This library supports the creation of a landing platform and a landing area, to check if rockets can land on it.

## Features
* Rockets can query the library to check if they are on a good trajectory
* Values returned by the library are "out of platform", "clash" and "ok for landing"
* More than one rocket can land on the same platform if there is at least one unit of separation between them
* Platform and Area size are configurable

## Details
* This library uses Nullable reference types to minimize NRE errors
* Has a small collection of unit tests
* Fully documented with XML DOC
