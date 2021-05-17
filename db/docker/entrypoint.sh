#!/bin/bash

# Start SQL Server
/opt/mssql/bin/sqlservr &

# Start the script to create the DB
/usr/config/configure-db.sh

# Call extra command
eval $1