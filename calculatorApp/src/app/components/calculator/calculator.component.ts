import { Component } from '@angular/core';
import { ApiService } from '../../Services/api.service';
import * as MATH_OP from '../../CommonClasses/Constants';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrl: './calculator.component.css'
})
export class CalculatorComponent {

  MathCalculationform!: FormGroup;
  options: string[] = ['Addition', 'Multiplication', 'Division', 'Substraction'];
  selectedOption: any = this.options[0]; // Default to the first option
  input1: any = 0;
  input2: any = 0;
  result: any = 0;
  strMessage: any = "";
  strErrorMessage: any = "";
  isformSubmitted: boolean = false;

  constructor(private _apiService: ApiService) {
    this.MathCalculationform = new FormGroup({
      input1: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      input2: new FormControl('', [Validators.required, Validators.maxLength(10)])
    });
  }


  ngOnInit() {

  }

  onSubmit(): void {
    //  this.strErrorMessage="";this.strMessage="";
    //   if ((this.input1 == 0 || this.input1 == null) && (this.input2 == 0 ||this.input2 == null)) {
    //     this.strErrorMessage = MATH_OP.Message.Mandatory_Message;
    //     return;
    //   } else {
    //     if (this.input2 == 0 && this.selectedOption == MATH_OP.Math_Operation.MULTIPLICATION) {
    //       this.strErrorMessage = MATH_OP.Message.DivideByZero_Message
    //       return;
    //     }
    if (this.MathCalculationform.valid) {
      const isFormValid = this.MathCalculationform.valid;

      this.input1=this.MathCalculationform.value['input1'];
      this.input2=this.MathCalculationform.value['input2'];
      
      this.isformSubmitted = true;
      if (isFormValid) {
        switch (this.selectedOption) {
          case 'Addition':
            this._apiService.CalculateValue(this.input1, this.input2, MATH_OP.OpCode.ADDITION)
              .then((response) => {
                response.subscribe((res) => {
                  this.result = res.payload;
                  this.strMessage = res.message;
                });
              })
              .catch(error => {
                // Handle the error here
                this.result = null; // Clear any previous results
                this.strErrorMessage = 'An error occurred while processing your request. Please try again later.';
                console.error('Error:', error); // Log the error for debugging
              });

            break;
          case 'Multiplication':
            this._apiService.CalculateValue(this.input1, this.input2, MATH_OP.OpCode.MULTIPLICATION)
              .then((response) => {
                response.subscribe((res) => {
                  this.result = res.payload; this.strMessage = res.message;
                });
              })
              .catch(error => {
                // Handle the error here
                this.result = null; // Clear any previous results
                this.strErrorMessage = 'An error occurred while processing your request. Please try again later.';
                console.error('Error:', error); // Log the error for debugging
              });
            break;
          case 'Substraction':
            this._apiService.CalculateValue(this.input1, this.input2, MATH_OP.OpCode.SUBSTRACTION)
              .then((response) => {
                response.subscribe((res) => {
                  this.result = res.payload; this.strMessage = res.message;
                });
              })
              .catch(error => {
                // Handle the error here
                this.result = null; // Clear any previous results
                this.strErrorMessage = 'An error occurred while processing your request. Please try again later.';
                console.error('Error:', error); // Log the error for debugging
              });
            break;
          case 'Division':
            this._apiService.CalculateValue(this.input1, this.input2, MATH_OP.OpCode.DIVISION)
              .then((response) => {
                response.subscribe((res) => {
                  this.result = res.payload; this.strMessage = res.message;
                });
              })
              .catch(error => {
                // Handle the error here
                this.result = null; // Clear any previous results
                this.strErrorMessage = 'An error occurred while processing your request. Please try again later.';
                console.error('Error:', error); // Log the error for debugging
              });
            break;

          default:
            break;
        }
      }
    }
  }

  clearAllControls() {
    this.input1 = 0;
    this.input2 = 0;
    this.strMessage = "";
  }
}
