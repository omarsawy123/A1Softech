import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })

export class EmployeeService {

    private headers: HttpHeaders;
    constructor(private _http: HttpClient) {

        this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    }


    baseUrl: string = "https://localhost:5001/employee";


    getAllEmployees(): Observable<EmployeeDto[]> {

        return this._http.get<EmployeeDto[]>(this.baseUrl);

    }

    getEmployee(Id: number): Observable<EmployeeDto> {
        return this._http.get<EmployeeDto>(this.baseUrl + "/" + Id)
    }

    addEmployee(employee: EmployeeDto) {

        debugger
        return this._http.post<EmployeeDto>(this.baseUrl, employee,
            {
                headers: new HttpHeaders({
                    'Content-Type': 'application/json'
                })
            });

    }

    editEmployee(employee: EmployeeDto) {

        debugger
        return this._http.put<EmployeeDto>(this.baseUrl, employee,
            {
                headers: new HttpHeaders({
                    'Content-Type': 'application/json'
                })
            });

    }

    deleteEmployee(Id: number): Observable<void> {
        return this._http.delete<void>(this.baseUrl + "/" + Id)
    }

}


export class EmployeeDto {

    id: number;
    name: string;
    mobile: number;
    email: string;
    salary: number;
    taxRate: number;
    netSalary: number;

}