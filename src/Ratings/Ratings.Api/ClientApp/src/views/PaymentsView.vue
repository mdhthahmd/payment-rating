<script setup>
import { ref } from 'vue'
import axios from 'axios'

import dayjs from 'dayjs'
import customParseFormat  from 'dayjs/plugin/customParseFormat'
dayjs.extend(customParseFormat)


const PagedPaymentList = ref({})

axios
    .get("api/payments")
    .then(response => PagedPaymentList.value = response.data);


const CurrencyFormatter = new Intl.NumberFormat('en-US', {
  style: 'currency',
  currency: 'USD',
});

</script>

<template>
    <div class="py-10">
        <header>
            <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
                <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Payments</h1>
            </div>
        </header>
        <main>
            <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">

                <!-- Content -->
                <div class="px-4 py-8 sm:px-0">


                    <div class="sm:flex sm:items-center">
                        <div class="sm:flex-auto">
                            <h1 class="text-base font-semibold leading-6 text-gray-900">Payment History</h1>
                            <p class="mt-2 text-sm text-gray-700">A table of all payments that have been recevied from employers</p>
                        </div>
                      
                    </div>
                    <div class="mt-8 flow-root">
                        <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
                            <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
                                <table class="min-w-full divide-y divide-gray-300">
                                    <thead>
                                        <tr>
                                            <th scope="col"
                                                class="whitespace-nowrap py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-gray-900 sm:pl-0">
                                                #</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Month</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900">
                                                Company</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-right text-sm font-semibold text-gray-900">
                                                Amount</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-center text-sm font-semibold text-gray-900">
                                                Due Date</th>
                                            <th scope="col"
                                                class="whitespace-nowrap px-2 py-3.5 text-right text-sm font-semibold text-gray-900">
                                                Payment Date</th>

                                            
                                        </tr>
                                </thead>
                                <tbody class="divide-y divide-gray-200 bg-white">
                                    <tr v-for="payment in PagedPaymentList.data" :key="payment.id">
                                        <td class="whitespace-nowrap py-2 pl-4 pr-3 text-sm text-gray-500 sm:pl-0">{{
                                            payment.id }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-gray-500">{{
                                            dayjs(payment.contributionMonth).format('YYYY/MM') }}</td>    
                                        <td class="whitespace-nowrap px-2 py-2 text-sm font-medium text-gray-900">{{
                                            payment.employer }}</td> 
                                        <td class="whitespace-nowrap px-2 py-2 text-sm text-right font-medium text-green-500">{{
                                            CurrencyFormatter.format(payment.amount) }}</td>
                                        <td class="whitespace-nowrap px-2 py-2 text-center text-sm text-gray-900">{{
                                            dayjs(payment.dueDate).format('DD MMMM YYYY') }}</td>
                                        <td class="whitespace-nowrap text-right px-2 py-2 text-sm text-gray-500">{{
                                            dayjs(payment.paymentDate).format('DD MMMM YYYY hh:mm:ss') }}</td>
                                                                           
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <nav class="flex items-center justify-between border-t border-gray-200 bg-white py-3"
                    aria-label="Pagination">
                    <div class="hidden sm:block">
                        <p class="text-sm text-gray-700">
                            Showing
                            {{ ' ' }}
                            <span class="font-medium">{{ (PagedPaymentList.pageNumber-1) *  PagedPaymentList.pageSize + 1 }}</span>
                            {{ ' ' }}
                            to
                            {{ ' ' }}
                            <span class="font-medium">{{  PagedPaymentList.totalRecords > PagedPaymentList.pageNumber *  PagedPaymentList.pageSize ? PagedPaymentList.pageNumber *  PagedPaymentList.pageSize : PagedPaymentList.totalRecords }}</span>
                            {{ ' ' }}
                            of
                            {{ ' ' }}
                            <span class="font-medium">{{ PagedPaymentList.totalRecords }}</span>
                            {{ ' ' }}
                            results
                        </p>
                    </div>
                    <div class="flex flex-1 justify-between sm:justify-end">
                        <a href="#"
                            class="relative inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Previous</a>
                        <a href="#"
                            class="relative ml-3 inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Next</a>
                    </div>
                </nav>



            </div>
            <!-- /End Content -->

        </div>
    </main>
</div></template>