export class ApiRegisterResponse {
  status?: Boolean
  data?: Array<string>
  errors?: [{
    errorMessage:string
  }]
}
export class ApiLoginRespose{
  status?: Boolean
  token?:string
  error?:string
}
