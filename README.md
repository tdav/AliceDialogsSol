
#   CREATE SERVICE
    nano /etc/systemd/system/alice_bot.service
    systemctl enable alice_bot.service
    systemctl start alice_bot.service


[Unit]
Description=Alice Yandex Server

[Service]
WorkingDirectory=/var/www/alice_yandex_bot
ExecStart=/var/www/alice_yandex_bot/alice_bot --urls=http://localhost:55010/
Restart=always

RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=admin_server

User=root
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target
 