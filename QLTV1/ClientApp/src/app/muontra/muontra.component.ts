import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;
@Component({
  selector: 'app-muontra',
  templateUrl: './muontra.component.html',
  styleUrls: ['./muontra.component.css']
})
export class MuontraComponent implements OnInit {
  muontra: any={
    data:[],
    totalRecord:0,
    page:0,
    size:4,
    totalPage:0
  };

  muontra1: any ={
    maThe:1,
    ngaymuon:"2019-07T00:00:00"
  };
  isEdit: boolean=true;
  

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) {}
    
  ngOnInit() {
    this.searchmuontra(1);
  }

  searchmuontra(cPage){
    let x ={
      page:cPage,
      size:4,
      keyword:""
    }
    this.http.post('https://localhost:44304/api/Muontra/search-muon-tra',x).subscribe(result => {
      this.muontra = result;
      this.muontra = this.muontra.data;
      
    }, error => console.error(error));
  }
  searchNext(){
    
    if(this.muontra.page<this.muontra.totalPage){
      let nextPage =this.muontra.page + 1;
      let x ={
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/api/Muontra/search-muon-tra',x).subscribe(result => {
        this.muontra = result;
        this.muontra = this.muontra.data;
      }, error => console.error(error));
    }
    else(alert("Bạn đang ở trang cuối !!!!"))
  }
  searchPrevious(){
    if(this.muontra.page>1){
      let nextPage =this.muontra.page - 1;
      let x ={
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/api/Muontra/search-muon-tra',x).subscribe(result => {
        this.muontra = result;
        this.muontra = this.muontra.data;
      }, error => console.error(error));
    }
    else(alert("Bạn đang ở trang đầu tiên !!!!"))
  }
  


  openModal(isNew,index)
  {
    if(isNew)
    {
      this.isEdit= false;
        this.muontra1 ={
        maThe:0,
        ngaymuon:""
      }
    }
    else{
      this.isEdit= true;
      this.muontra1 =this.muontra.data[index];
    }
    $('#exampleModal').modal("show");
  }
  addmuontra()
  {
    var x =this.muontra1;
    this.http.post('https://localhost:44304/api/Muontra/create-muon-tra',x).subscribe(result=>{
      var res:any =result;
      if(res.success){
        this.muontra1=res.data;
        this.isEdit=true;}
        this.searchmuontra(1);
        alert("Bạn đã tạo thành công");
    }, error=>console.error(error));}
  updatemuontra()
  {
    var x =this.muontra1;
    this.http.post('https://localhost:44304/api/Muontra/update-muon-tra',x).subscribe(result=>{
      var res:any =result;
      if(res.success)
      {
        this.muontra1=res.data;
        this.isEdit=true;}
        this.searchmuontra(1);
        alert("Bạn đã cập nhật thành công");
    }, error=>console.error(error));}
    deletemuontra(index){
      var r=confirm("Bạn muốn xóa nó chứ?");
      if(r == true){
        this.muontra1=this.muontra.data[index];
        var x = this.muontra1;
        this.http.post('https://localhost:44304/api/Muontra/delete-muon-tra',x).subscribe(result=>{
          var res: any=result;
          if(res.success){
            this.searchmuontra(1);
            alert("Bạn đã xóa thành công");
          }
          else {
            alert(res.message);
          }
        },error=>{
          console.error(error);
          alert(error);
        }
        );
      }
      
    }
  
}



  