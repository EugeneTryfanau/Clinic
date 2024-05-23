#!/bin/sh

if [ "$#" -lt 3 ]; then
  echo "Usage: $0 host port command"
  exit 1
fi

HOST=$1
PORT=$2
shift 2

while ! wget -q --spider "https://$HOST:$PORT"; do
  echo "Waiting for $HOST:$PORT..."
  sleep 1
done

exec "$@"
