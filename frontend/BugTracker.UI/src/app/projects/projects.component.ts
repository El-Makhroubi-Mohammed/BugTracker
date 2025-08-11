import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {
  projects: any[] = [];

  constructor(private projectService: ProjectService, private router: Router) {}

  ngOnInit() {
    this.projectService.getUserProjects().subscribe({
      next: (data) => this.projects = data,
      error: (err) => console.error(err)
    });
  }

  viewBugs(projectId: number) {
    this.router.navigate([`/projects/${projectId}/bugs`]);
  }
}
