import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BugService {
  private apiUrl = 'http://localhost:5000/api/Bugs';

  constructor(private http: HttpClient) {}

  getBugsByProject(projectId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/project/${projectId}`);
  }

  updateBug(bug: any): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${bug.id}`, bug);
  }

  createBug(bug: any): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}`, bug);
}

}
