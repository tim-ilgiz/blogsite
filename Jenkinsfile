pipeline {
    agent any

    options {
        skipDefaultCheckout true
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                dir ('server') {
                	sh 'docker-compose build --no-cache'
                }                                
            }
        }
        stage('Deploy') {
            steps {
                dir ('server') {
                    sh 'docker system prune -f -a'
                	sh 'docker-compose rm -f -s -v'
                    sh 'docker-compose up -d'
                }
                
            }
        }
    }
}
