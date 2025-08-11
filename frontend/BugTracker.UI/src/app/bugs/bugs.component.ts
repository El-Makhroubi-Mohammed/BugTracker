import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BugService } from '../services/bug.service';

@Component({
  selector: 'app-bugs',
  templateUrl: './bugs.component.html',
  styleUrls: ['./bugs.component.css']
})
export class BugsComponent implements OnInit {
  bugs: any[] = [];
  statuses = ['Open', 'InProgress', 'Resolved'];
  newBug = {
    title: '',
    description: '',
    status: 'Open',
    projectId: 0
  };

  constructor(private route: ActivatedRoute, private bugService: BugService) {}

  ngOnInit() {
    const projectId = Number(this.route.snapshot.paramMap.get('id'));
    this.newBug.projectId = projectId;
    this.loadBugs(projectId);
  }

  loadBugs(projectId: number) {
    this.bugService.getBugsByProject(projectId).subscribe({
      next: (data) => this.bugs = data,
      error: (err) => console.error(err)
    });
  }

  onStatusChange(bug: any, newStatus: string) {
    const updatedBug = { ...bug, status: newStatus };
    this.bugService.updateBug(updatedBug).subscribe({
      next: () => {
        bug.status = newStatus;
      },
      error: (err) => console.error(err)
    });
  }
  createBug() {
    this.bugService.createBug(this.newBug).subscribe({
      next: (createdBug) => {
        this.bugs.push(createdBug);
        this.loadBugs(this.newBug.projectId); 
        this.newBug.title = '';
        this.newBug.description = '';
        this.newBug.status = 'Open';
      },
      error: (err) => console.error(err)
    });
  }
}
