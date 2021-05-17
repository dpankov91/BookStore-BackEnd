FROM mcr.microsoft.com/mssql/server

RUN mkdir -p /usr/config
WORKDIR /usr/config

COPY . /usr/config

USER root
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh
USER mssql

ENTRYPOINT ["./entrypoint.sh"]

CMD ["tail -f /dev/null"]