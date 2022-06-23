import { isNull } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from 'src/Services/Employee.services';
import { EmployeeDto } from 'src/Services/Employee.services';

@Component({
    selector: 'Employee',
    templateUrl: 'Employee.component.html'
})


export class EmployeeComponent implements OnInit {


    Employee_List: EmployeeDto[] = [];
    showForm: boolean = false;
    Employee_Form: FormGroup;

    constructor(private _employeeService: EmployeeService, private _fb: FormBuilder) { }

    ngOnInit() {

        this.mainForm();
        this._employeeService.getAllEmployees().subscribe((result) => {
            this.Employee_List = result;
        })

    }


    checkForNetSalary() {
        let salary = this.Employee_Form.get('salary').value;
        let tax = this.Employee_Form.get('tax').value;

        if (salary != null && tax != null) {

            let netSalary = salary - (tax * salary) / 100;
            this.Employee_Form.get('netSalary').setValue(netSalary);
        }

    }


    mainForm() {

        this.Employee_Form = this._fb.group({

            id: [],
            name: ['', Validators.required],
            mobile: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            tax: ['', Validators.required],
            salary: ['', Validators.required],
            netSalary: [{ value: '', disabled: true },],
        })


    }


    AddorUpdateEmployee(id?: number) {

        if (id) {

        }
        else {

            this.mainForm();
            this.showForm = true;
        }
    }

    getEmployee(id: number) {
        let emp;

        this._employeeService.getEmployee(id).subscribe((res) => {
            this.Employee_Form.get('name').setValue(res.name)
            this.Employee_Form.get('email').setValue(res.email)
            this.Employee_Form.get('mobile').setValue(res.mobile)
            this.Employee_Form.get('tax').setValue(res.taxRate)
            this.Employee_Form.get('salary').setValue(res.salary)
            this.Employee_Form.get('netSalary').setValue(res.netSalary)
            this.showForm = true;
        })

    }

    deleteEmployee(id: number) {
        debugger;
        this._employeeService.deleteEmployee(id).subscribe((res) => {
            window.location.reload();
        });
    }


    saveEmployee() {

        debugger

        if (this.Employee_Form.valid) {

            let model = new EmployeeDto();

            model.id = null;
            model.name = this.Employee_Form.get('name').value;
            model.email = this.Employee_Form.get('email').value;
            model.mobile = this.Employee_Form.get('mobile').value;
            model.salary = this.Employee_Form.get('salary').value;
            model.taxRate = this.Employee_Form.get('tax').value;
            model.netSalary = this.Employee_Form.get('netSalary').value;

            this._employeeService.addEmployee(model).subscribe((res) => {
                console.log(res);
            })

        }


    }
}