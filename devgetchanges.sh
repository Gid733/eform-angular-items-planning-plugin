#!/bin/bash

cd ~

rm -fR Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/src/app/plugins/modules/items-planning-pn

cp -a Documents/workspace/microting/eform-angular-frontend/eform-client/src/app/plugins/modules/items-planning-pn Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/src/app/plugins/modules/items-planning-pn

rm -fR Documents/workspace/microting/eform-angular-items-planning-plugin/eFormAPI/Plugins/ItemsPlanning.Pn

cp -a Documents/workspace/microting/eform-angular-frontend/eFormAPI/Plugins/ItemsPlanning.Pn Documents/workspace/microting/eform-angular-items-planning-plugin/eFormAPI/Plugins/ItemsPlanning.Pn

# Test files rm
rm -fR Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/e2e/Tests/items-planning-settings/
rm -fR Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/e2e/Tests/items-planning-general/
rm -fR Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/wdio-headless-plugin-step2.conf.js

# Test files cp
cp -a Documents/workspace/microting/eform-angular-frontend/eform-client/e2e/Tests/items-planning-settings Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/e2e/Tests/items-planning-settings
cp -a Documents/workspace/microting/eform-angular-frontend/eform-client/e2e/Tests/items-planning-general Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/e2e/Tests/items-planning-general
cp -a Documents/workspace/microting/eform-angular-frontend/eform-client/wdio-plugin-step2.conf.js Documents/workspace/microting/eform-angular-items-planning-plugin/eform-client/wdio-headless-plugin-step2.conf.js
