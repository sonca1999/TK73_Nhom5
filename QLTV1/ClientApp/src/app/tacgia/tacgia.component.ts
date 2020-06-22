import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-tacgia',
  templateUrl: './tacgia.component.html',
  styleUrls: ['./tacgia.component.css']
})
export class TacgiaComponent implements OnInit {
  tacgias: any={
    data:[],
    totalRecord: 0,
    page:0,
    size:4,
    totalPage:0
  };

  tacgia: any={
    maTg:1,
    tenTg:"Yeah",
    ghiChu:""
  };
  isEdit: boolean = true;
  
  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchTacgia(1);
  }

  searchTacgia(cPage){
    let x={
      page:cPage,
      size:4,
      keyword:""
    }
    this.http.post('https://localhost:44304/api/Tacgia/search-tac-gia', x).subscribe(result=>{
      this.tacgias=result;
      this.tacgias = this.tacgias.data;
    }, error => console.error(error));
  }
  searchNext(){
    if(this.tacgias.page< this.tacgias.totalPage){
      let nextpage = this.tacgias.page + 1;
      let x={
        page:nextpage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/api/Tacgia/search-tac-gia', x).subscribe(result=>{
        this.tacgias=result;
        this.tacgias = this.tacgias.data;
      }, error => console.error(error));

    }
    else{
      alert("Bạn đang ở trang cuối!");
    }
  }

  searchPrevious(){
    if(this.tacgias.page>1){
      let previouspage = this.tacgias.page - 1;
      let x={
        page:previouspage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/api/Tacgia/search-tac-gia', x).subscribe(result=>{
        this.tacgias=result;
        this.tacgias = this.tacgias.data;
      }, error => console.error(error));

    }
    else{
      alert("Bạn đang ở trang đầu");
    }
  }
  openModal(isNew,index)
  {
    if(isNew){
      this.isEdit = false;
      this.tacgia = {
        maTg:0,
        tenTg:"",
        ghiChu:""
      }
    }
    else{
      this.isEdit = true;
      this.tacgia =this.tacgias.data[index];
    }
    $('#exampleModal').modal("show");
  }
  addTacgia()
  {
    var x = this.tacgia
    this.http.post('https://localhost:44304/api/Tacgia/create-tac-gia', x).subscribe(result=>{
      var res:any =result;
      if(res.success){
        this.tacgia=res.data;
        this.isEdit=true;
        this.searchTacgia(1);
        alert ("Tạo thành công!");
      }
    }, error => console.error(error));
  }
  updateTacgia()
  {
    var x = this.tacgia
    this.http.post('https://localhost:44304/api/Tacgia/update-tac-gia', x).subscribe(result=>{
      var res:any =result;
      if(res.success){
        this.tacgia=res.data;
        this.isEdit=true;
        this.searchTacgia(1);
        alert ("Cập nhật thành công!");
      }
    }, error => console.error(error));
  }
  deleteTacgia(index)
  {
    var r = confirm("Bạn muốn xóa tác giả này?");
    if(r == true)
    {
      this.tacgia = this.tacgias.data[index];
      var x = this.tacgia;
      this.http.post('https://localhost:44304/api/Tacgia/delete-tac-gia', x)
      .subscribe(result => {
        var res: any = result;
        if (res.success) 
        {
          this.searchTacgia(1);
          alert("Tác giả này đã được xóa thành công!");
        }
        else
        {
          alert(res.message);
        }
      }, error => {
          console.error(error);
          alert(error);
      });
    }
  }

}
