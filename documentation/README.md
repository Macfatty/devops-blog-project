# DevOps Blog Project

This project showcases an automated deployment of a blog using modern DevOps practices including Continuous Integration/Continuous Deployment (CI/CD), Docker, Jenkins, Terraform, Kubernetes, AWS cloud infrastructure, and comprehensive monitoring with Prometheus, Grafana, and MongoDB.

## 📌 Project Overview
The goal of this project is to automate the end-to-end deployment process of a DevOps blog application, leveraging infrastructure as code (IaC), containerization, and monitoring tools to ensure scalability, security, and maintainability.

## 🚀 Features

- **CI/CD Pipeline:** Automated builds and deployments using Jenkins and GitHub Actions.
- **Docker & Kubernetes:** Containerized applications managed via Docker and Kubernetes (K3s).
- **Terraform & AWS:** Infrastructure automation with Terraform for AWS cloud resources.
- **Monitoring Stack:** Real-time monitoring with Prometheus, visualized through Grafana dashboards, and logged into MongoDB.
- **Security & Backup:** Automated backups stored securely in AWS S3, with IAM roles ensuring secure resource management.

## 🛠️ Tech Stack

- **CI/CD:** Jenkins, GitHub Actions
- **Containerization:** Docker, Docker Compose
- **Orchestration:** Kubernetes (K3s)
- **Cloud & Infrastructure:** AWS, Terraform
- **Monitoring & Logging:** Prometheus, Grafana, MongoDB, MongoDB Exporter
- **Backend:** .NET 8 (ASP.NET Core)
- **Security:** NGINX reverse proxy with SSL (Let's Encrypt), AWS IAM roles

## 📁 Project Structure
```
devops-blog-project/
├── .github/workflows/       # CI/CD workflow definitions
├── infrastructure/          # Terraform and Kubernetes configurations
├── jenkins/                 # Jenkins pipelines and scripts
├── docker/                  # Dockerfiles and Docker Compose setups
├── src/dotnet-app/          # Source code for the .NET application
├── scripts/                 # Backup and deployment scripts
├── monitoring/              # Grafana dashboards and monitoring configurations
├── documentation/           # Detailed project documentation and setup guides
└── tests/                   # Unit and integration tests
```

## 🔧 Getting Started

### Prerequisites
- Git, Docker, Terraform, Kubernetes (K3s)
- AWS Account (EC2, S3, IAM)

### Installation & Deployment
Clone the repository:
```bash
git clone https://github.com/Macfatty/devops-blog-project.git
cd devops-blog-project
```

Refer to the [setup guides](documentation/setup-guides/) for detailed deployment instructions.

## 📈 Monitoring & Logging
Access Grafana dashboards at:
```
http://<your-server-ip>:3000
```

## ✅ Future Improvements
- Expand Terraform automation to include auto-scaling and multi-region deployments.
- Enhance CI/CD pipeline with automated tests.
- Implement advanced security scans and alerting systems.

## 🤝 Contributing
Contributions are welcome! Please fork the repository, create a branch, commit your changes, and submit a pull request.

## 📜 License
Distributed under the MIT License.

## 📬 Contact
Feel free to contact me via GitHub: [Macfatty](https://github.com/Macfatty)


 
