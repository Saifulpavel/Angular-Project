import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-dept',
  templateUrl: './show-dept.component.html',
  styleUrls: ['./show-dept.component.css']
})
export class ShowDeptComponent implements OnInit {

  constructor(private service: SharedService) { }
DepartmentList: any = [];
ModalTitle: string;
ActivateAddEditDeptComp: boolean= false;
dept: any;
  ngOnInit(): void {
    this.refreshDeptList();
  }
  addClick(){
    this.dept = {
      DepartmentId: 0,
      DepartmentName: ''
    };
    this.ModalTitle = 'Add Department';
    this.ActivateAddEditDeptComp = true;
  }
  editClick(item){
    this.dept = item;
    this.ModalTitle = 'Edit Department';
    this.ActivateAddEditDeptComp = true;
  }
  deleteClick(item){
    if (confirm('Are you sure want to delete??')){
      this.service.deleteDepartment(item.DepartmentId).subscribe(data => {
        alert(data.toString());
        this.refreshDeptList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditDeptComp = false;
    this.refreshDeptList();
  }
  refreshDeptList(){
    this.service.getDeptList().subscribe(data => {
      this.DepartmentList = data;
    });
  }
}
