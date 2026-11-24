#!/bin/bash
set -e

awslocal sqs create-queue --queue-name watchtower-checks-dlq

awslocal sqs create-queue --queue-name watchtower-checks --attributes '{"RedrivePolicy":"{\"deadLetterTargetArn\":\"arn:aws:sqs:us-east-1:000000000000:watchtower-checks-dlq\",\"maxReceiveCount\":\"3\"}"}'