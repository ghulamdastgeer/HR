export interface EmployeeList {
    id: number;
    name: string;
    phoneNo: string;
    paidTimeOff: number;
    dob: Date;
    gender: string;
    employeeDesignation: {
        name: string;
    };
    salary: {
     salaries: number;
    };
    benefits: [];
    userId: number;
    departmentResource: {
     name: string;
    };
    address: {
        streetAddress: string;
        addressTypes: number;
        cityId: number;
    };
    employeeImageResource: [
    ];
}
